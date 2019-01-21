using _8anu.Api.Common.Interfaces;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IBaseSlugManager<TSlugEntity> where TSlugEntity : class, ISlugEntity
    {
        TSlugEntity GetBySlug(string slug);
    }
}