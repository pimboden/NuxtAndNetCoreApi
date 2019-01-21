namespace _8anu.Api.Common.Runtime.Caching
{
    public interface ICacheHandler
    {
        IObjectCache ForumCategoryCache { get; }
        object ForumCategoryCacheLock { get; }


        IObjectCache ForumCache { get; }
        object ForumCacheLock { get; }

        IObjectCache ArticleCache { get; }
        object ArticleCacheLock { get; }

        IObjectCache CountryCache { get; }
        object CountryCacheLock { get; }

        IObjectCache NewsCache { get; }
        object NewsCacheLock { get; }

        IObjectCache TestModelCache { get; }
        object TestModelCacheLock { get; }

        IObjectCache CragsCache { get; }
        object CragsCacheLock { get; }
        
        bool ClearCaches(string password);

    }
}