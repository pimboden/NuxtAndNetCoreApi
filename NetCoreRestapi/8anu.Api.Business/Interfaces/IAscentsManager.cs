using System.Collections.Generic;
using System.Data;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;

namespace _8anu.Api.Managers.Interfaces
{
    public interface IAscentsManager:IBaseManager<Ascent>
    {
        List<Ascent> GetAllForZlaggable(string zlaggableSlug, ZlaggableCategoryEnum category, string sectorSlug, int pageIndex = 0, string sortField = "", int pageSize = 50);
    }
}