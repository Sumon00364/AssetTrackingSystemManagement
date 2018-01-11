using System;
using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetSetupGetways
{
    public class AssetGroupGetway : IRepositoryGetway<AssetGroup>
    {
        private readonly AssetGroupUnitOfWork _assetGroupUnitOfWork;
        public AssetGroupGetway()
        {
            _assetGroupUnitOfWork = new AssetGroupUnitOfWork(new AssetDbContext());
        }
        

        public AssetGroup Get(int id)
        {
            return _assetGroupUnitOfWork.AssetGroup.Get(id);
        }

        public IEnumerable<AssetGroup> GetAll()
        {
            return _assetGroupUnitOfWork.AssetGroup.GetAll();
        }

        public int Add(AssetGroup entity)
        {
            _assetGroupUnitOfWork.AssetGroup.Add(entity);
            return _assetGroupUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<AssetGroup> entities)
        {
            _assetGroupUnitOfWork.AssetGroup.AddRange(entities);
            return _assetGroupUnitOfWork.Complete();
        }

        public int Update(AssetGroup entity)
        {
            _assetGroupUnitOfWork.AssetGroup.Update(entity);
            return _assetGroupUnitOfWork.Complete();
        }

        public int Remove(AssetGroup entity)
        {
            _assetGroupUnitOfWork.AssetGroup.Remove(entity);
            return _assetGroupUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<AssetGroup> entities)
        {
            _assetGroupUnitOfWork.AssetGroup.RemoveRange(entities);
            return _assetGroupUnitOfWork.Complete();
        }

        public AssetGroup GetAssetGroupByName(string name)
        {
            return _assetGroupUnitOfWork.AssetGroup.GetAssetGroupByName(name);
        }

        public AssetGroup GetAssetGroupByShortName(string shortName)
        {
            return _assetGroupUnitOfWork.AssetGroup.GetAssetGroupByShortName(shortName);
        }

        public AssetGroup GetAssetGroupByGroupCode(string code)
        {
            return _assetGroupUnitOfWork.AssetGroup.GetAssetGroupByGroupCode(code);
        }

        public IEnumerable<AssetGroup> AssetGroupsWithAssetType()
        {
            return _assetGroupUnitOfWork.AssetGroup.AssetGroupsWithAssetType();
        }

        public IEnumerable<AssetGroup> Find(int id)
        {   
            throw new NotImplementedException();
        }

        public AssetGroup SingleAssetGroup(int id)
        {
            throw new NotImplementedException();    
        }
    }
}
