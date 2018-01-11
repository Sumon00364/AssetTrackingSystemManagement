using System.Collections.Generic;
using System.Data.Entity;
using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;

namespace Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetEntryRepositories
{
    public class AssetEntryRepository : Repository<AssetEntry>, IAssetEntryRepository
    {
        public AssetEntryRepository(DbContext context) 
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

        public AssetEntry GetAssetEntryByAssetId(string idNo)
        {
            throw new System.NotImplementedException();
        }

        public AssetEntry GetAssetEntryByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public AssetEntry GetAssetEntryBySerialNo(string serialNo)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AssetEntry> AssetEntriesWithOrganiztionBranchLocationTypeGroupManufactureModel()
        {
            throw new System.NotImplementedException();
        }
    }
}
