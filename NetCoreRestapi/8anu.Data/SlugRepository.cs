using System.Linq;
using Microsoft.EntityFrameworkCore;
using _8anu.Api.Common.Interfaces;

namespace _8anu.Data
{
    public class SlugRepository<TSlugEntity> : Repository<TSlugEntity> where TSlugEntity : class, ISlugEntity
    {
        public SlugRepository(DbContext context) : base(context)
        {


        }
        public TSlugEntity GetBySlug(string slug)
        {
            return Context.Set<TSlugEntity>().FirstOrDefault(x => x.Slug.Equals(slug));
        }
    }
}