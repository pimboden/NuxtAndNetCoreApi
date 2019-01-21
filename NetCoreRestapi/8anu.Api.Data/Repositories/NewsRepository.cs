using System.Collections.Generic;
using System.Linq;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories
{
    public class NewsRepository:Repository<NewsItem>, INewsRepository
    {
        public NewsRepository(DomainModelMySqlContext context) : base(context)
        {
        }

        public IEnumerable<NewsItem> GetLatestNews(int pageIndex = 0, int pageSize = 10)
        {
            return GetAll(pageIndex, pageSize).OrderByDescending(n=>n.DatePublished);
        }
    }
}