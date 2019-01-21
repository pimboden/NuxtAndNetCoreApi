using System.Collections.Generic;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories.Interfaces
{
    public interface IAscentsRepository: IRepository<Ascent>
    {
        List<Ascent> GetAllForZlaggable(int zlaggableId, ZlaggableCategoryEnum category, int pageIndex = 0, int pageSize = 50, string sortField = "");
        
        Task<Dictionary<string, ZlaggableWithStatistics>> GetZlaggablesWithStatistics(
            Dictionary<int, SectorWithStatistics> sectors);

        HashSet<AscentWithUserInfo> GetAscentsWithUserInfo(Dictionary<string, ZlaggableWithStatistics> zlaggables);
    }
}
