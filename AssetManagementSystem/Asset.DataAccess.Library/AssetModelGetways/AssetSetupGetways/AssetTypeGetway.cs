using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetSetupGetways
{
    public class AssetTypeGetway :IRepositoryGetway<AssetType>
    {
        private readonly AssetTypeUnitOfWork _assetTypeUnitOfWork;
        public AssetTypeGetway()
        {
            _assetTypeUnitOfWork = new AssetTypeUnitOfWork(new AssetDbContext());
        }



        public AssetType Get(int id)
        {
            return _assetTypeUnitOfWork.AssetType.Get(id);
        }

        public IEnumerable<AssetType> GetAll()
        {
            return _assetTypeUnitOfWork.AssetType.GetAll();
        }

        public int Add(AssetType entity)
        {
            _assetTypeUnitOfWork.AssetType.Add(entity);
            return _assetTypeUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetType> entities)
        {
            _assetTypeUnitOfWork.AssetType.AddRange(entities);
            return _assetTypeUnitOfWork.Complete();
        }

        public int Update(AssetType entity)
        {
            _assetTypeUnitOfWork.AssetType.Update(entity);
            return _assetTypeUnitOfWork.Complete();
        }

        public int Remove(AssetType entity)
        {
            _assetTypeUnitOfWork.AssetType.Remove(entity);
            return _assetTypeUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetType> entities)
        {
            _assetTypeUnitOfWork.AssetType.RemoveRange(entities);
            return _assetTypeUnitOfWork.Complete();
        }
    }
}
