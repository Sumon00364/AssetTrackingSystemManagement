using System.Collections.Generic;
using Asset.DataAccess.Library.AssetModelGetways.AssetSetupGetways;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetSetupManagers
{
    public class AssetManufactureManager : IRepositoryManager<AssetManufacurer>
    {
        private readonly AssetManufactureGetway _assetManufactureGetway;
        public AssetManufactureManager()
        {
            _assetManufactureGetway = new AssetManufactureGetway();
        }



        public bool IsAssetManufactureNameExist(string name)
        {
            bool isName = false;
            var assetManufacture = GetAssetManufactureByName(name);
            if (assetManufacture != null)
            {
                isName = true;
            }
            return isName;
        }

        private AssetManufacurer GetAssetManufactureByName(string name)
        {
            return _assetManufactureGetway.GetAssetManufactureByName(name);
        }


        public bool AssetManufactureByShortNameExist(string shortName)
        {
            bool isShortName = false;
            var assetManufacture = GetAssetManufactureByShortName(shortName);
            if (assetManufacture != null)
            {
                isShortName = true;
            }
            return isShortName;
        }

        private AssetManufacurer GetAssetManufactureByShortName(string shortName)
        {
            return _assetManufactureGetway.GetAssetManufactureByShortName(shortName);
        }


        public bool IsAssetManufactureCodeExist(string code)
        {
            bool isCode = false;
            var assetManufacture = GetAssetManufactureByCode(code);
            if (assetManufacture != null)
            {
                isCode = true;
            }
            return isCode;
        }

        private AssetManufacurer GetAssetManufactureByCode(string code)
        {
            return _assetManufactureGetway.GetAssetManufactureByCode(code);
        }

        public IEnumerable<AssetManufacurer> AssetManufacurersWithAssetGroup()
        {
            return _assetManufactureGetway.AssetManufacurersWithAssetGroup();
        }


        public IEnumerable<AssetManufacurer> FindById(int id)
        {
            return _assetManufactureGetway.Find(id);
        }

        public AssetManufacurer SingleAssetManufacurer(int id)
        {
            return _assetManufactureGetway.SingleAssetManufacturer(id);
        }



        public AssetManufacurer Get(int id)
        {
            return _assetManufactureGetway.Get(id);
        }

        public IEnumerable<AssetManufacurer> GetAll()
        {
            return _assetManufactureGetway.GetAll();
        }

        public int Add(AssetManufacurer entity)
        {
            return _assetManufactureGetway.Add(entity);
        }

        public int AddRange(IEnumerable<AssetManufacurer> entities)
        {
            return _assetManufactureGetway.AddRange(entities);
        }

        public int Update(AssetManufacurer entity)
        {
            return _assetManufactureGetway.Update(entity);
        }

        public int Remove(AssetManufacurer entity)
        {
            return _assetManufactureGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<AssetManufacurer> entities)
        {
            return _assetManufactureGetway.RemoveRange(entities);
        }
    }
}
