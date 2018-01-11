using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetSetupGetways
{
    public class AssetLocationGetway : IRepositoryGetway<AssetLocation>
    {
        private readonly AssetLocationUnitOfWork _assetLocationUnitOfWork;
        public AssetLocationGetway()
        {
            _assetLocationUnitOfWork = new AssetLocationUnitOfWork(new AssetDbContext());
        }


        public AssetLocation Get(int id)
        {
            return _assetLocationUnitOfWork.AssetLocation.Get(id);
        }

        public IEnumerable<AssetLocation> GetAll()
        {
            return _assetLocationUnitOfWork.AssetLocation.GetAll();
        }

        public int Add(AssetLocation entity)
        {
            _assetLocationUnitOfWork.AssetLocation.Add(entity);
            return _assetLocationUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetLocation> entities)
        {
            _assetLocationUnitOfWork.AssetLocation.AddRange(entities);
            return _assetLocationUnitOfWork.Complete();
        }

        public int Update(AssetLocation entity)
        {
            _assetLocationUnitOfWork.AssetLocation.Update(entity);
            return _assetLocationUnitOfWork.Complete();
        }

        public int Remove(AssetLocation entity)
        {
            _assetLocationUnitOfWork.AssetLocation.Remove(entity);
            return _assetLocationUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetLocation> entities)
        {
            _assetLocationUnitOfWork.AssetLocation.RemoveRange(entities);
            return _assetLocationUnitOfWork.Complete();
        }

        public AssetLocation GetAssetLocationByName(string name)
        {
            return _assetLocationUnitOfWork.AssetLocation.GetAssetLocationByName(name);
        }

        public AssetLocation GetAssetLocationByShortName(string shortName)
        {
            return _assetLocationUnitOfWork.AssetLocation.GetAssetLocationByShortName(shortName);
        }

        public AssetLocation GetAssetLocationByCode(string code)
        {
            return _assetLocationUnitOfWork.AssetLocation.GetAssetLocationByCode(code);
        }

        public IEnumerable<AssetLocation> AssetLocationsWithOrganizationAndBranch()
        {
            return _assetLocationUnitOfWork.AssetLocation.AssetLocationsWithOrganizationAndBranch();
        }

        public AssetLocation SingleAssetLocation(int id)
        {
            return _assetLocationUnitOfWork.AssetLocation.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<AssetLocation> Find(int id)
        {
            return _assetLocationUnitOfWork.AssetLocation.Find(a => a.Id == id);
        }
    }
}
