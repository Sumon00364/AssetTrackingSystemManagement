using System.Collections.Generic;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups
{
    public interface IAssetGroupRepository : IRepository<AssetGroup>
    {
        AssetGroup GetAssetGroupByName(string name);
        AssetGroup GetAssetGroupByShortName(string shortName);
        AssetGroup GetAssetGroupByGroupCode(string code);
        IEnumerable<AssetGroup> AssetGroupsWithAssetType(); 
    }
}
