using System.Collections.Generic;
using Asset.DataAccess.Library.AssetModelGetways.AssetSetupGetways;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetSetupManagers
{
    public class AssetLocationManager : IRepositoryManager<AssetLocation>
    {
        private readonly AssetLocationGetway _assetLocationGetway;
        public AssetLocationManager()
        {
            _assetLocationGetway = new AssetLocationGetway();
        }


        public bool IsAssetLocationNameExist(string name)
        {
            bool isName = false;
            var assetLocationName = GetAssetLocationByName(name);
            if (assetLocationName != null)
            {
                isName = true;
            }
            return isName;
        }

        private AssetLocation GetAssetLocationByName(string name)
        {
            return _assetLocationGetway.GetAssetLocationByName(name);
        }

        public bool IsAssetLocatoinShortNameExist(string shortName)
        {
            bool isShortName = false;
            var assetLocationShortName = GetAssetLocationByShortName(shortName);
            if (assetLocationShortName != null)
            {
                isShortName = true;
            }
            return isShortName;
        }

        private AssetLocation GetAssetLocationByShortName(string shortName)
        {
            return _assetLocationGetway.GetAssetLocationByShortName(shortName);
        }

        public bool IsAssetLocationByCodeExist(string code)
        {
            bool isCode = false;
            var assetLocationCode = GetAssetLocationByCode(code);
            if (assetLocationCode != null)
            {
                isCode = true;
            }
            return isCode;
        }

        private AssetLocation GetAssetLocationByCode(string code)
        {
            return _assetLocationGetway.GetAssetLocationByCode(code);
        }

        public IEnumerable<AssetLocation> AssetLocationsWithOrganizationAndBranch()
        {
            return _assetLocationGetway.AssetLocationsWithOrganizationAndBranch();
        }

        public AssetLocation SingleAssetLocation(int id)
        {
            return _assetLocationGetway.SingleAssetLocation(id);
        }
        
        public IEnumerable<AssetLocation> FindById(int id)
        {
            return _assetLocationGetway.Find(id);
        }



        public AssetLocation Get(int id)
        {
            return _assetLocationGetway.Get(id);
        }

        public IEnumerable<AssetLocation> GetAll()
        {
            return _assetLocationGetway.GetAll();
        }

        public int Add(AssetLocation entity)
        {
            return _assetLocationGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetLocation> entities)
        {
            return _assetLocationGetway.AddRange(entities);
        }

        public int Update(AssetLocation entity)
        {
            return _assetLocationGetway.Update(entity);
        }

        public int Remove(AssetLocation entity)
        {
            return _assetLocationGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetLocation> entities)
        {
            return _assetLocationGetway.RemoveRange(entities);
        }
    }
}
