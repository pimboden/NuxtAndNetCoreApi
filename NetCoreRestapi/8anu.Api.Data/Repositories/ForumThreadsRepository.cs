using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Models;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories
{
    public class ForumThreadsRepository : Repository<ForumThread>, IForumThreadsRepository
    {
        public ForumThreadsRepository(DomainModelMySqlContext context) : base(context)
        {
        }

        public async Task<int> GetThreadsCountByCategoryIdAsync(int categorId)
        {
            return await Context
                .Set<ForumThread>()
                .CountAsync(x => x.ForumCategory.Id.Value == categorId);
        }

        public async Task<List<ForumThreadWithCounts>> GetForumThreadsByCategorySlugAsync(string categorySlug,
            int pageIndex = 0, int pageSize = 50)
        {
            var foundCategories = new List<ForumThreadWithCounts>();
            var conn = Context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                const string query = @"select main.id, main.title, main.slug, main.forum_category_id,
(select count(fc.id) from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.id = main.id) as commentCount,
(select fc.date_created from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.id = main.id order by fc.date_created desc limit 1) as lastCommentDate,
(select ft.slug from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id where ft.id = main.id order by fc.date_created desc limit 1) as lastCommentSlug,
(select CONCAT(u.first_name, ' ', u.last_name) from forum_comments fc inner join forum_threads ft on fc.forum_thread_id = ft.id inner join users u on fc.user_id = u.id where ft.id = main.id order by fc.date_created desc limit 1) as lastCommentUserName
from forum_threads main
inner join forum_categories fg on fg.id = main.forum_category_id
where fg.slug like @categorySlug
order by lastCommentDate desc";
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.Add(new MySqlParameter("categorySlug", categorySlug));
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new ForumThreadWithCounts
                            {
                                ThreadId = reader.GetInt32(0),
                                ThreadTitle = reader.GetString(1),
                                ThreadSlug = reader.GetString(2),
                                ThreadCategory = reader.GetInt32(3),
                                CommentsCount = reader.GetInt32(4),
                                LatesCommentDate = !reader.IsDBNull(5) ? reader.GetDateTime(5) : (DateTime?) null,
                                LatesCommentThreadSlug = !reader.IsDBNull(6) ? reader.GetString(6) : null,
                                LatesCommentUserFullName = !reader.IsDBNull(7) ? reader.GetString(7) : null,

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