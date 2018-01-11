using System.Collections.Generic;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys
{
    public interface IAssetEntryRepository : IRepository<AssetEntry>
    {
        AssetEntry GetAssetEntryByAssetId(string idNo);
        AssetEntry GetAssetEntryByName(string name);
        AssetEntry GetAssetEntryBySerialNo(string serialNo);
        IEnumerable<AssetEntry> AssetEntriesWithOrganiztionBranchLocationTypeGroupManufactureModel();
    }
}   
