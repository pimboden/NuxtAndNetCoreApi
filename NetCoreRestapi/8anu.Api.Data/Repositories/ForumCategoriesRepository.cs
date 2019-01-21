using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;
using MySql.Data.MySqlClient;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Data.Repositories
{
    public class ForumCategoriesRepository : SlugRepository<ForumCategory>, IForumCategoriesRepository
    {
        public ForumCategoriesRepository(DomainModelMySqlContext context) : base(context)
        {
        }

        public async Task<List<ForumCategoryWithCounts>> GetRootForumCategoryWithCountsAsync(int pageIndex = 0, int pageSize = 50)
        {
            var foundCategories = new List<ForumCategoryWithCounts>();
            var conn = Context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                const string query = @"select cats.id, cats.name, cats.slug,
(select count(threads.id) from forum_threads as threads where forum_category_id = cats.id) as threadcount,
(select count(fc.id) from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.forum_category_id = cats.id) as comentcount,
(select fc.id from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.forum_category_id = cats.id order by fc.date_created desc limit 1) as lastCommentId,
(select ft.slug from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.forum_category_id = cats.id order by fc.date_created desc limit 1) as lastCommentThreadSlug,
(select fc.date_created from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.forum_category_id = cats.id order by fc.date_created desc limit 1) as lastCommentDate,
(select CONCAT(u.first_name, ' ', u.last_name) from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id inner join users u on fc.user_id = u.id where ft.forum_category_id = cats.id order by fc.date_created desc limit 1) as lastCommentUserName
from forum_categories cats
where cats.parent_id is null";
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new ForumCategoryWithCounts
                            {
                                CategoryId = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                                CategorySlug = reader.GetString(2),
                                ThreadsCount = reader.GetInt32(3),
                                CommentsCount = reader.GetInt32(4),
                                LatesCommentThreadSlug = !reader.IsDBNull(6) ? reader.GetString(6):null,
                                LatesCommentDate = !reader.IsDBNull(7) ? reader.GetDateTime(7) : (DateTime?) null,
                                LatesCommentUserFullName = !reader.IsDBNull(8) ? reader.GetString(8) : null
                            };
                            foundCategories.Add(row);
                        }
                    }

                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            return foundCategories;

        }


        public async Task<List<ForumCategoryWithCounts>> GetForumCategoryWithCountsByParentSlugAsync(string parentSlug,int pageIndex = 0, int pageSize = 50)
        {
            var foundCategories = new List<ForumCategoryWithCounts>();
            var conn = Context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                const string query = @"select cats.id, cats.name, cats.slug,
(select count(threads.id) from forum_threads as threads where forum_category_id = cats.id) as threadcount,
(select count(fc.id) from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.forum_category_id = cats.id) as comentcount,
(select fc.id from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.forum_category_id = cats.id order by fc.date_created desc limit 1) as lastCommentId,
(select ft.slug from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.forum_category_id = cats.id order by fc.date_created desc limit 1) as lastCommentThreadSlug,
(select fc.date_created from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.forum_category_id = cats.id order by fc.date_created desc limit 1) as lastCommentDate,
(select CONCAT(u.first_name, ' ', u.last_name) from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id inner join users u on fc.user_id = u.id where ft.forum_category_id = cats.id order by fc.date_created desc limit 1) as lastCommentUserName
from forum_categories cats inner join  forum_categories parentCategory 
on( parentCategory.id = cats.parent_id)
where parentCategory.slug like @parentSlug";
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.Add(new MySqlParameter("parentSlug", parentSlug));
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new ForumCategoryWithCounts
                            {
                                CategoryId = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                                CategorySlug = reader.GetString(2),
                                ThreadsCount = reader.GetInt32(3),
                                CommentsCount = reader.GetInt32(4),
                                LatesCommentThreadSlug = !reader.IsDBNull(6) ? reader.GetString(6) : null,
                                LatesCommentDate = !reader.IsDBNull(7) ? reader.GetDateTime(7) : (DateTime?)null,
                                LatesCommentUserFullName = !reader.IsDBNull(8) ? reader.GetString(8) : null
                            };
                            foundCategories.Add(row);
                        }
                    }

                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            return foundCategories;

        }
    }
}