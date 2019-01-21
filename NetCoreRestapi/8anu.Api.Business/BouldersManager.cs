using _8anu.Api.Common.DataEntities;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Api.Managers.Interfaces;

namespace _8anu.Api.Managers
{
    public class BouldersManager: BaseManager<Boulder>, IBouldersManager
    {

        private readonly IBouldersRepository _bouldersRepository;
        public BouldersManager(IBouldersRepository bouldersRepository):base(bouldersRepository)
        {
            _bouldersRepository = bouldersRepository;
        }
    }
}