using System.Collections.Generic;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups
{
    public interface IAssetManufacurerRepository : IRepository<AssetManufacurer>
    {
        AssetManufacurer GetAssetManufactureByName(string name);
        AssetManufacurer GetAssetManufactureByShortName(string shortName);
        AssetManufacurer GetAssetManufactureByCode(string code);
        IEnumerable<AssetManufacurer> AssetManufacurersWithAssetGroup();            
    }
}
