using _8anu.Api.Common.Interfaces;

namespace _8anu.Data
{
    public interface ISlugRepository<TSlugEntity> : IRepository<TSlugEntity> where TSlugEntity : class, ISlugEntity
    {
        TSlugEntity GetBySlug(string slug);
    }
}