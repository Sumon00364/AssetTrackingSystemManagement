using System.Collections.Generic;
using Asset.DataAccess.Library.AssetModelGetways.AssetSetupGetways;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetSetupManagers
{
    public class AssetGroupManager : IRepositoryManager<AssetGroup>
    {
        private readonly AssetGroupGetway _assetGroupGetway;
        public AssetGroupManager()
        {
            _assetGroupGetway = new AssetGroupGetway();
        }

        public bool IsAssetGroupNameExist(string name)
        {
            bool issName = false;
            var assetGroupName = GetAssetGroupByName(name);
            if (assetGroupName != null)
            {
                issName = true;
            }
            return issName;
        }

        private AssetGroup GetAssetGroupByName(string name)
        {
            return _assetGroupGetway.GetAssetGroupByName(name);
        }

        public bool IsAssetGroupShortNameExist(string shortName)
        {
            bool isShortName = false;
            var assetGroupShortName = GetAssetGroupByShortName(shortName);
            if (assetGroupShortName != null )
            {
                isShortName = true;
            }
            return isShortName;
        }

        private AssetGroup GetAssetGroupByShortName(string shortName)
        {
            return _assetGroupGetway.GetAssetGroupByShortName(shortName);
        }

        public bool IsAssetGroupCodeExist(string code)
        {
            bool isCode = false;
            var assetGroupCode = GetAssetGroupByGroupCode(code);
            if (assetGroupCode != null)
            {
                isCode = true;
            }
            return isCode;
        }

        private AssetGroup GetAssetGroupByGroupCode(string code)
        {
            return _assetGroupGetway.GetAssetGroupByGroupCode(code);
        }

        public IEnumerable<AssetGroup> AssetGroupsWithAssetType()
        {
            return _assetGroupGetway.AssetGroupsWithAssetType();
        }

        public IEnumerable<AssetGroup> FindById(int id)
        {
            return _assetGroupGetway.Find(id);
        }

        public AssetGroup SingleAssetGroup(int id)
        {
            return _assetGroupGetway.SingleAssetGroup(id);
        }




        public AssetGroup Get(int id)
        {
            return _assetGroupGetway.Get(id);
        }

        public IEnumerable<AssetGroup> GetAll()
        {
            return _assetGroupGetway.GetAll();
        }

        public int Add(AssetGroup entity)
        {
            return _assetGroupGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetGroup> entities)
        {
            return _assetGroupGetway.AddRange(entities);
        }

        public int Update(AssetGroup entity)
        {
            return _assetGroupGetway.Update(entity);
        }

        public int Remove(AssetGroup entity)
        {
            return _assetGroupGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetGroup> entities)
        {
            return _assetGroupGetway.RemoveRange(entities);
        }
    }
}
