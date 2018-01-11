using System.Collections.Generic;
using Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetEntryManagers
{
    public class AssetEntryManager : IRepositoryManager<AssetEntry>
    {
        private readonly AssetEntryGetway _assetEntryGetway;
        public AssetEntryManager()
        {
            _assetEntryGetway = new AssetEntryGetway();
        }


        public bool IsAssetIdNoExist(string idNo)
        {
            bool isIdNo = false;
            var assetEntry = GetAssetEntryByAssetId(idNo);
            if (assetEntry != null)
            {
                isIdNo = true;
            }
            return isIdNo;
        }

        private AssetEntry GetAssetEntryByAssetId(string idNo)
        {
            return _assetEntryGetway.GetAssetEntryByAssetId(idNo);
        }

        public bool IsAssetNameExist(string name)
        {
            bool isName = false;
            var assetEntry = GetAssetEntryByName(name);
            if (assetEntry != null)
            {
                isName = true;
            }
            return isName;
        }

        private AssetEntry GetAssetEntryByName(string name)
        {
            return _assetEntryGetway.GetAssetEntryByName(name);
        }

        public bool IsSerialNoExist(string serialNo)
        {
            bool isSerialNo = false;
            var assetEntry = GetAssetEntryBySerialNo(serialNo);
            if (assetEntry != null)
            {
                isSerialNo = true;
            }
            return isSerialNo;
        }

        private AssetEntry GetAssetEntryBySerialNo(string serialNo)
        {
            return _assetEntryGetway.GetAssetEntryBySerialNo(serialNo);
        }


        public IEnumerable<AssetEntry> AssetEntriesWithOrganiztionBranchLocationTypeGroupManufactureModel()
        {
            return _assetEntryGetway.AssetEntriesWithOrganiztionBranchLocationTypeGroupManufactureModel();
        }

        public IEnumerable<AssetEntry> FindById(int id)
        {
            return _assetEntryGetway.Find(id);
        }

        public AssetEntry SingleAssetEntry(int id)
        {
            return _assetEntryGetway.SingleAssetEntry(id);
        }



        public AssetEntry Get(int id)
        {
            return _assetEntryGetway.Get(id);
        }

        public IEnumerable<AssetEntry> GetAll()
        {
            return _assetEntryGetway.GetAll();
        }

        public int Add(AssetEntry entity)
        {
            return _assetEntryGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetEntry> entities)
        {
            return _assetEntryGetway.AddRange(entities);
        }

        public int Update(AssetEntry entity)
        {
            return _assetEntryGetway.Update(entity);
        }

        public int Remove(AssetEntry entity)
        {
            return _assetEntryGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetEntry> entities)
        {
            return _assetEntryGetway.RemoveRange(entities);
        }
    }
}
