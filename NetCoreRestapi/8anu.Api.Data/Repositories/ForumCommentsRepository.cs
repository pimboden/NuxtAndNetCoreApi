using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ForumCommentsRepository : Repository<ForumComment>, IForumCommentsRepository
    {
        public ForumCommentsRepository(DomainModelMySqlContext context) : base(context)
        {
        }

        public async Task<List<ForumComment>> GetLatestCommentsByCategorySlugAsync(string categorySlug,
            int pageIndex = 0,
            int pageSize = 50)
        {
            return await Context.Set<ForumComment>()
                .Where(x => x.ForumThread.ForumCategory.Slug.Equals(categorySlug)).OrderByDescending(x => x.DateCreated)
                .Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<ForumComment> GetLatestCommentByCategoryIdAsync(int categoryId)
        {
            return await Context.Set<ForumComment>()
                .Where(x => x.ForumThread.ForumCategory.Id.Value == categoryId).OrderByDescending(x => x.DateCreated)
                .Include(x => x.User).Include(x => x.ForumThread)
                .FirstOrDefaultAsync();
        }

        public async Task<ForumComment> GetLatestCommentByThreadIdAsync(int threadId)
        {
            return await Context.Set<ForumComment>()
                .Where(x => x.ForumThread.Id.Value == threadId).OrderByDescending(x => x.DateCreated)
                .Include(x => x.User)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetCommentsCountByCategoryIdAsync(int categoryId)
        {
            return await Context
                .Set<ForumComment>()
                .CountAsync(x => x.ForumThread.ForumCategory.Id.Value == categoryId);
        }

        public async Task<int> GetCommentsCountByThreadIdAsync(int threadId)
        {
            return await Context
                .Set<ForumComment>()
                .CountAsync(x => x.ForumThread.Id.Value == threadId);
        }

        public async Task<List<ForumComment>> GetLatestCommentsAsync(int pageIndex = 0, int pageSize = 50)
        {
            return await Context.Set<ForumComment>().OrderByDescending(x => x.DateCreated)
                .Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<ThreadComment>> GetThreadComments(int threadId, int pageIndex, int pageSize)
        {
            var foundComments = new List<ThreadComment>();
            var conn = Context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                const string query =
                    @"SELECT fc.id, fc.date_created, fc.content,  concat(users.first_name , ' ' ,users.last_name  ) as user_fullname, users.slug as userslug  
FROM forum_comments fc inner join users
on(fc.user_id = users.id)
where fc.forum_thread_id = @threadId
order by fc.date_created asc";
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.Add(new MySqlParameter("threadId", threadId));
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new ThreadComment
                            {
                                Id = reader.GetInt32(0),
                                Created = reader.GetDateTime(1),
                                Content = reader.GetString(2),
                                UserFullName = reader.GetString(3),
                                UserSlug = reader.GetString(4),
                            };
                            foundComments.Add(row);
                        }
                    }

                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            return foundComments;

        }

        public async Task<ThreadInfo> GetThreadInfoRootCategory(string categorySlug, string threadSlug)
        {
            ThreadInfo threadInfo = null;
            var conn = Context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                const string query =
                    @"SELECT ft.id, ft.date_created, ft.slug, ft.title,  concat(users.first_name , ' ' ,users.last_name  ) as user_fullname, users.slug as userslug  
FROM forum_threads ft inner join users
on(ft.user_id = users.id) inner join forum_categories cat
on(ft.forum_category_id =cat.id) 
where ft.slug like @threadSlug
and cat.slug = @categorySlug";
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.Add(new MySqlParameter("categorySlug", categorySlug));
                    command.Parameters.Add(new MySqlParameter("threadSlug", threadSlug));
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        if (await reader.ReadAsync())
                        {
                            threadInfo = new ThreadInfo
                            {
                                Id = reader.GetInt32(0),
                                Created = reader.GetDateTime(1),
                                Slug = reader.GetString(2),
                                Title = reader.GetString(3),
                                UserFullName = reader.GetString(4),
                                UserSlug = reader.GetString(5),
                            };
                        }
                    }

                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            return threadInfo;
        }


        public async Task<ThreadInfo> GetThreadInfoSubCategory(string categorySlug, string subcategorySlug,
            string threadSlug)
        {
            ThreadInfo threadInfo = null;
            var conn = Context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                const string query =
                    @"SELECT ft.id, ft.date_created, ft.slug, ft.title,  concat(users.first_name , ' ' ,users.last_name  ) as user_fullname, users.slug as userslug  
FROM forum_threads ft inner join users
on(ft.user_id = users.id) inner join forum_categories subcat
on(ft.forum_category_id =subcat.id) inner join forum_categories cat
on(cat.id =subcat.parent_id)
where ft.slug like @threadSlug
and subcat.slug like @subcategorySlug
and cat.slug = @categorySlug";
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.Add(new MySqlParameter("categorySlug", categorySlug));
                    command.Parameters.Add(new MySqlParameter("subcategorySlug", subcategorySlug));
                    command.Parameters.Add(new MySqlParameter("threadSlug", threadSlug));
                    var reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        if (await reader.ReadAsync())
                        {
                            threadInfo = new ThreadInfo
                            {
                                Id = reader.GetInt32(0),
                                Created = reader.GetDateTime(1),
                                Slug = reader.GetString(2),
                                Title = reader.GetString(3),
                                UserFullName = reader.GetString(4),
                                UserSlug = reader.GetString(5),
                            };
                        }
                    }

                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }

            return threadInfo;
        }
    }
}