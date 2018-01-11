using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetSetupGetways
{
    public class AssetManufactureGetway : IRepositoryGetway<AssetManufacurer>
    {
        private readonly AssetManufacturerUnitOfWork _assetManufacturerUnitOfWork;
        public AssetManufactureGetway()
        {
            _assetManufacturerUnitOfWork = new AssetManufacturerUnitOfWork(new AssetDbContext());
        }


        public AssetManufacurer Get(int id)
        {
            return _assetManufacturerUnitOfWork.AssetManufacturer.Get(id);
        }

        public IEnumerable<AssetManufacurer> GetAll()
        {
            return _assetManufacturerUnitOfWork.AssetManufacturer.GetAll();
        }

        public int Add(AssetManufacurer entity)
        {
            _assetManufacturerUnitOfWork.AssetManufacturer.Add(entity);
            return _assetManufacturerUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetManufacurer> entities)
        {
            _assetManufacturerUnitOfWork.AssetManufacturer.AddRange(entities);
            return _assetManufacturerUnitOfWork.Complete();
        }

        public int Update(AssetManufacurer entity)
        {
            _assetManufacturerUnitOfWork.AssetManufacturer.Update(entity);
            return _assetManufacturerUnitOfWork.Complete();
        }

        public int Remove(AssetManufacurer entity)
        {
            _assetManufacturerUnitOfWork.AssetManufacturer.Remove(entity);
            return _assetManufacturerUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetManufacurer> entities)
        {
            _assetManufacturerUnitOfWork.AssetManufacturer.RemoveRange(entities);
            return _assetManufacturerUnitOfWork.Complete();
        }



        public AssetManufacurer GetAssetManufactureByName(string name)
        {
            return _assetManufacturerUnitOfWork.AssetManufacturer.GetAssetManufactureByName(name);
        }

        public AssetManufacurer GetAssetManufactureByShortName(string shortName)
        {
            return _assetManufacturerUnitOfWork.AssetManufacturer.GetAssetManufactureByShortName(shortName);
        }

        public AssetManufacurer GetAssetManufactureByCode(string code)
        {
            return _assetManufacturerUnitOfWork.AssetManufacturer.GetAssetManufactureByCode(code);
        }

        public IEnumerable<AssetManufacurer> AssetManufacurersWithAssetGroup()
        {
            return _assetManufacturerUnitOfWork.AssetManufacturer.AssetManufacurersWithAssetGroup();
        }

        public IEnumerable<AssetManufacurer> Find(int id)
        {
            return _assetManufacturerUnitOfWork.AssetManufacturer.Find(am => am.Id == id);
        }

        public AssetManufacurer SingleAssetManufacturer(int id)
        {
            return _assetManufacturerUnitOfWork.AssetManufacturer.SingleOrDefault(am => am.Id == id);
        }
    }
}
