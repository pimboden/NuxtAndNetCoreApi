using _8anu.Api.Common.DataEntities;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories
{
    public class BouldersRepository:Repository<Boulder>, IBouldersRepository
    {
        public BouldersRepository(DomainModelMySqlContext context) : base(context)
        {
        }
    }
}