using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetSetupGetways
{
    public class AssetModelGetway :IRepositoryGetway<AssetModel>
    {
        private readonly AssetModelUnitOfWork _assetModelUnitOfWork;
        public AssetModelGetway()
        {
            _assetModelUnitOfWork = new AssetModelUnitOfWork(new AssetDbContext());
        }


        public AssetModel Get(int id)
        {
            return _assetModelUnitOfWork.AssetModel.Get(id);
        }

        public IEnumerable<AssetModel> GetAll()
        {
            return _assetModelUnitOfWork.AssetModel.GetAll();
        }

        public int Add(AssetModel entity)
        {
            _assetModelUnitOfWork.AssetModel.Add(entity);
            return _assetModelUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetModel> entities)
        {
            _assetModelUnitOfWork.AssetModel.AddRange(entities);
            return _assetModelUnitOfWork.Complete();
        }

        public int Update(AssetModel entity)
        {
            _assetModelUnitOfWork.AssetModel.Update(entity);
            return _assetModelUnitOfWork.Complete();
        }

        public int Remove(AssetModel entity)
        {
            _assetModelUnitOfWork.AssetModel.Remove(entity);
            return _assetModelUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetModel> entities)
        {
            _assetModelUnitOfWork.AssetModel.RemoveRange(entities);
            return _assetModelUnitOfWork.Complete();
        }
    }
}
