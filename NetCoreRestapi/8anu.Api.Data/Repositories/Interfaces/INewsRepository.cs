using System.Collections.Generic;
using _8anu.Api.Common.DataEntities;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface INewsRepository: IRepository<NewsItem>
    {
        IEnumerable<NewsItem> GetLatestNews(int pageIndex = 0, int pageSize = 10);
    }
}
