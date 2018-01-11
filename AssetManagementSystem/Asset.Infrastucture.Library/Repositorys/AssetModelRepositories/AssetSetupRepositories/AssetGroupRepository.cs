using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;

namespace Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetSetupRepositories
{
    public class AssetGroupRepository : Repository<AssetGroup>, IAssetGroupRepository
    {
        public AssetGroupRepository(DbContext context) 
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

        public AssetGroup GetAssetGroupByName(string name)
        {
            var assetGroup = AssetDbContext.AssetGroups.SingleOrDefault(ag => ag.Name == name);
            return assetGroup;
        }

        public AssetGroup GetAssetGroupByShortName(string shortName)
        {
            var assetGroup = AssetDbContext.AssetGroups.SingleOrDefault(ag => ag.ShortName == shortName);
            return assetGroup;
        }

        public AssetGroup GetAssetGroupByGroupCode(string code)
        {
            var assetGroup = AssetDbContext.AssetGroups.SingleOrDefault(ag => ag.GroupCode == code);
            return assetGroup;
        }

        public IEnumerable<AssetGroup> AssetGroupsWithAssetType()
        {
            var assetGroup = AssetDbContext.AssetGroups.Include(ag => ag.AssetType);
            return assetGroup;
        }
    }
}
