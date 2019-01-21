using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using _8anu.Data.Migration.Model;
using System.Linq;
using _8anu.Api.Common.DataEntities;
using _8anu.Data.Migration.Utilities;
using System.IO;
using System.Text;

namespace _8anu.Data.Migration.Generators
{
    public class ForumThreads : IGenerator
    {
        private int currentThreadId = 0;

        public ForumThreads()
        {
        }

        Dictionary<int, ForumThread> newThreads;
        public string Generate(int maxRows, string staticFileName = "") {
            
            Console.Write(Environment.NewLine);

            var context = new _8a_oldContext();
            newThreads = new Dictionary<int, ForumThread>();
            var threadComments = new Dictionary<int, ForumComment>();

            // add forum general
            var oldThreads = context.Set<Model.ForumThreads>().Where(f => f.CountryCode == "GLOBAL"
                                                                     && f.ObjectClass == "CLS_ForumGeneral").ToList();
            AddThreads(context, oldThreads, newThreads, threadComments, 1);

            // add forum dr8a
            oldThreads = context.Set<Model.ForumThreads>().Where(f => f.ObjectClass == "CLS_ForumDr8a").ToList();
            AddThreads(context, oldThreads, newThreads, threadComments, 2);

            // add country specific forums
            var countryCategories = SeedStore.ForumCategories.Values.Where(c => c.ParentId == 3).ToList();
            foreach(var countryCategory in countryCategories) {
                var iso3 = SeedStore.Countries.Values.Where(c => c.Slug == countryCategory.Slug).FirstOrDefault().ISO3;
                oldThreads = context.Set<Model.ForumThreads>().Where(f => f.ObjectClass == "CLS_ForumGeneral" && f.CountryCode == iso3).ToList();
                AddThreads(context, oldThreads, newThreads, threadComments, countryCategory.Id.Value);
            }

            var newComments =  SeedStore.ThreadComments.Concat(threadComments).ToDictionary(x => x.Key, x => x.Value);
            SeedStore.ThreadComments = newComments;

            var json = JsonConvert.SerializeObject(newThreads.Values);
            return json;
        }

        private int currentNewThreadCommentId = 1;
        private void AddThreads(_8a_oldContext context, List<Model.ForumThreads> oldThreads, Dictionary<int, ForumThread> newThreads, Dictionary<int, ForumComment> newThreadComments, int ForumCategoryId) 
        {
            var skippedThreadsCount = 0;
            var skippedCommentsCount = 0;
            
            foreach (var oldthread in oldThreads)
            {
                // jump over if this thread don't have any comments
                var oldComments = context.Set<Model.ObjectComments>()
                                         .Where(c => c.ObjectId == oldthread.ObjectId && c.ObjectClass == oldthread.ObjectClass)
                                         .OrderByDescending(c => c.Date).ToList();


                if (!oldComments.Any())
                {
                    continue;
                }

                var userId = oldthread.UserId == 0 ? SeedStore.GetZeroUserId() : (int)oldthread.UserId;

                // jump over if this thread is created by user that is not moved to new system for some reason
                if (!SeedStore.AddedUserIds.Contains(userId))
                {
                    Console.WriteLine("no user found from added users, skipped thread id: " + oldthread.Id);
                    skippedThreadsCount++;
                    continue;
                }

                var newThread = new ForumThread
                {
                    Id = ++currentThreadId,
                    Slug = oldthread.Slug,
                    Title = oldthread.Head,
                    ForumCategoryId = ForumCategoryId,
                    UserId = userId
                };

                var isFirstComment = true;

                // create all comments
                foreach (var oldComment in oldComments)
                {
                    var commentUserId = oldComment.UserId == 0 ? SeedStore.GetZeroUserId() : (int)oldComment.UserId;

                    // jump over if this thread is created by user that is not moved to new system for some reason
                    if (!SeedStore.AddedUserIds.Contains(commentUserId))
                    {
                        skippedCommentsCount++;
                        Console.WriteLine("no user found from added users, skipped thread id: " + oldComment.Id);
                        continue;
                    }

                    // set date to thread if this is the first comment
                    if (isFirstComment)
                    {
                        isFirstComment = false;
                        newThread.DateCreated = oldComment.Date;
                        newThread.DateModified = oldComment.Date;
                    }

                    var newComment = new ForumComment
                    {
                        Id = currentNewThreadCommentId++,
                        ForumThreadId = currentThreadId,
                        UserId = commentUserId,
                        Content = oldComment.Text,
                        DateCreated = oldComment.Date,
                        DateModified = oldComment.Date,
                        LegacyId = (int)oldComment.Id
                    };
                    newThreadComments.Add(newComment.Id.Value, newComment);
                }

                newThreads.Add(newThread.Id.Value, newThread);
            }

            Console.WriteLine("skipped threads: " + skippedThreadsCount + ", skipped comments: " + skippedCommentsCount);
        }
    
        public void GenerateSqlFile(string path)
        {
            var tablename = "forum_threads";
            SeedStore.AddAllSqlString(tablename);
            var head = $@"TRUNCATE TABLE `{tablename}`;
ALTER TABLE `{tablename}` DISABLE KEYS;";
            var tail = $"ALTER TABLE `{tablename}` ENABLE KEYS;";
            var insertHead = @"INSERT INTO `" + tablename + @"` (`id`, `date_created`, `date_modified`, `forum_category_id`, `slug`, `title`, `user_id`)
VALUES";

            var currentPageRow = 1;
            var rowNumber = 0;
            var maxRowCountPerInsert = SeedStore.MAX_ROW_COUNT_PER_INSERT;
            var rowCount = newThreads.Count;


            using (var filestream = new FileStream(path, FileMode.Create))
            using (var sq = new StreamWriter(filestream))
            {
                sq.WriteLine(SeedStore.SQL_HEAD);
                sq.WriteLine(head);
                sq.WriteLine();
                sq.WriteLine(insertHead);
                foreach (var thread in newThreads.Values)
                {
                    rowNumber++;

                    if (currentPageRow > maxRowCountPerInsert)
                    {
                        sq.WriteLine();
                        sq.WriteLine(insertHead);
                        currentPageRow = 1;
                    }

                    var line = new StringBuilder("(");
                    line.Append(string.Join(",", new object[] {
                        thread.Id,
                        thread.DateCreated.ToSqlInsertString(),
                        thread.DateModified.ToSqlInsertString(),
                        thread.ForumCategoryId,
                        thread.Slug.ToSqlInsertString(),
                        thread.Title.ToSqlInsertStringEscape(false),
                        thread.UserId
                    }));

                    line.Append(")");

                    currentPageRow++;

                    if (currentPageRow <= maxRowCountPerInsert && rowNumber < rowCount)
                    {
                        line.Append(",");
                    }
                    else
                    {
                        line.Append(";");
                    }

                    sq.WriteLine(line);
                }

                sq.WriteLine();
                sq.WriteLine(tail);
                sq.WriteLine();
                sq.WriteLine(SeedStore.SQL_TAIL);
            }
        }
    }
}