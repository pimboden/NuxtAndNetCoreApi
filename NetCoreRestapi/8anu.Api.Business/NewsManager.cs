using System.Collections.Generic;
using System.Linq;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Managers
{
    public class NewsManager: BaseManager<NewsItem>, INewsManager
    {

        private readonly INewsRepository _newsRepository;
        public NewsManager(INewsRepository newsRepository):base(newsRepository)
        {

            _newsRepository = newsRepository;
        }

        public List<NewsItem> GetLatestNews(int pageIndex = 0, int pageSize = 10)
        {
            return _newsRepository.GetLatestNews(pageIndex, pageSize).ToList();
        }


    }
}