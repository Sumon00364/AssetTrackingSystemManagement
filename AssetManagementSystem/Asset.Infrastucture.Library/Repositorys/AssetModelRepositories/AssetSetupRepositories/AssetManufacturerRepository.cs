using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;

namespace Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetSetupRepositories
{
    public class AssetManufacturerRepository : Repository<AssetManufacurer>, IAssetManufacurerRepository
    {
        public AssetManufacturerRepository(DbContext context) 
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext
        {
            get
            {
                return Context as AssetDbContext;
            }
        }

        public AssetManufacurer GetAssetManufactureByName(string name)
        {
            var assetManufacture = AssetDbContext.AssetManufacurers.SingleOrDefault(am => am.Name == name);
            return assetManufacture;
        }

        public AssetManufacurer GetAssetManufactureByShortName(string shortName)
        {
            var assetManufacture = AssetDbContext.AssetManufacurers.SingleOrDefault(am => am.ShortName == shortName);
            return assetManufacture;
        }

        public AssetManufacurer GetAssetManufactureByCode(string code)
        {
            var assetManufacture = AssetDbContext.AssetManufacurers.SingleOrDefault(am => am.Code == code);
            return assetManufacture;
        }

        public IEnumerable<AssetManufacurer> AssetManufacurersWithAssetGroup()
        {
            var assetManufacture = AssetDbContext.AssetManufacurers.Include(ag => ag.AssetGroup);
            return assetManufacture;
        }
    }
}
