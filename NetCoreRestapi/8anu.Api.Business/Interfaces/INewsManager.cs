using System.Collections.Generic;
using _8anu.Api.Common.DataEntities;

namespace _8anu.Api.Managers.Interfaces
{
    public interface INewsManager:IBaseManager<NewsItem>
    {
        List<NewsItem> GetLatestNews(int pageIndex = 0, int pageSize = 10);
    }
}