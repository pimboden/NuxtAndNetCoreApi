using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.Models;

namespace _8anu.Api.Managers.Services
{
    public interface IStatisticsService
    {
        Task<bool> CreateStatistics();
        void CreateStatisticsForAscents(Dictionary<string, ZlaggableWithStatistics> zlaggables);
    }
}