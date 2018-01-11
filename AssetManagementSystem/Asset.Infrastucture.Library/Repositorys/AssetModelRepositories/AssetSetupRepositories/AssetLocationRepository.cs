using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;

namespace Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetSetupRepositories
{
    public class AssetLocationRepository : Repository<AssetLocation>, IAssetLocationRepository
    {
        public AssetLocationRepository(AssetDbContext context)
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

        public AssetLocation GetAssetLocationByName(string name)
        {
            var assetLocation = AssetDbContext.AssetLocations.SingleOrDefault(al => al.Name == name);
            return assetLocation;
        }

        public AssetLocation GetAssetLocationByShortName(string shortName)
        {
            var assetLocation = AssetDbContext.AssetLocations.SingleOrDefault(al => al.ShortName == shortName);
            return assetLocation;
        }

        public AssetLocation GetAssetLocationByCode(string code)
        {
            var assetLocation = AssetDbContext.AssetLocations.SingleOrDefault(al => al.AssetLocationCode == code);
            return assetLocation;
        }

        public IEnumerable<AssetLocation> AssetLocationsWithOrganizationAndBranch()
        {
            var assetLocationWithOrganizationAndBranch =
                                        AssetDbContext.AssetLocations.Include(o => o.Organization).Include(b => b.Branch);
            return assetLocationWithOrganizationAndBranch;
        }
    }
}
