using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways
{
    public class AssetEntryGetway : IRepositoryGetway<AssetEntry>
    {
        private readonly AssetEntryUnitOfWork _assetEntryUnitOfWork;
        public AssetEntryGetway()
        {
            _assetEntryUnitOfWork = new AssetEntryUnitOfWork(new AssetDbContext());
        }


        public AssetEntry Get(int id)
        {
            return _assetEntryUnitOfWork.AssetEntry.Get(id);
        }

        public IEnumerable<AssetEntry> GetAll()
        {
            return _assetEntryUnitOfWork.AssetEntry.GetAll();
        }

        public int Add(AssetEntry entity)
        {
            _assetEntryUnitOfWork.AssetEntry.Add(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetEntry> entities)
        {
            _assetEntryUnitOfWork.AssetEntry.AddRange(entities);
            return _assetEntryUnitOfWork.Complete();
        }

        public int Update(AssetEntry entity)
        {
            _assetEntryUnitOfWork.AssetEntry.Update(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int Remove(AssetEntry entity)
        {
            _assetEntryUnitOfWork.AssetEntry.Remove(entity);
            return _assetEntryUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetEntry> entities)
        {
            _assetEntryUnitOfWork.AssetEntry.RemoveRange(entities);
            return _assetEntryUnitOfWork.Complete();
        }

        public AssetEntry GetAssetEntryByAssetId(string idNo)
        {
            return _assetEntryUnitOfWork.AssetEntry.GetAssetEntryByAssetId(idNo);
        }

        public AssetEntry GetAssetEntryByName(string name)
        {
            return _assetEntryUnitOfWork.AssetEntry.GetAssetEntryByName(name);
        }

        public AssetEntry GetAssetEntryBySerialNo(string serialNo)
        {
            return _assetEntryUnitOfWork.AssetEntry.GetAssetEntryBySerialNo(serialNo);
        }

        public IEnumerable<AssetEntry> AssetEntriesWithOrganiztionBranchLocationTypeGroupManufactureModel()
        {
            return _assetEntryUnitOfWork.AssetEntry
                .AssetEntriesWithOrganiztionBranchLocationTypeGroupManufactureModel();
        }


        public IEnumerable<AssetEntry> Find(int id)
        {
            return _assetEntryUnitOfWork.AssetEntry.Find(ae => ae.Id == id);
        }

        public AssetEntry SingleAssetEntry(int id)
        {
            return _assetEntryUnitOfWork.AssetEntry.SingleOrDefault(ae => ae.Id == id);
        }
    }
}
