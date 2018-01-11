using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways
{
    public class ServiceAndRepairingGetway : IRepositoryGetway<ServiceOrRepairing>
    {
        private readonly ServiceAndRepairingUnitOfWork _serviceAndRepairingUnitOfWork;
        public ServiceAndRepairingGetway()
        {
            _serviceAndRepairingUnitOfWork = new ServiceAndRepairingUnitOfWork(new AssetDbContext());
        }


        public ServiceOrRepairing Get(int id)
        {
            return _serviceAndRepairingUnitOfWork.ServiceAndRrepairing.Get(id);
        }

        public IEnumerable<ServiceOrRepairing> GetAll()
        {
            return _serviceAndRepairingUnitOfWork.ServiceAndRrepairing.GetAll();
        }

        public int Add(ServiceOrRepairing entity)
        {
            _serviceAndRepairingUnitOfWork.ServiceAndRrepairing.Add(entity);
            return _serviceAndRepairingUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<ServiceOrRepairing> entities)
        {
            _serviceAndRepairingUnitOfWork.ServiceAndRrepairing.AddRange(entities);
            return _serviceAndRepairingUnitOfWork.Complete();
        }

        public int Update(ServiceOrRepairing entity)
        {
            _serviceAndRepairingUnitOfWork.ServiceAndRrepairing.Update(entity);
            return _serviceAndRepairingUnitOfWork.Complete();
        }

        public int Remove(ServiceOrRepairing entity)
        {
            _serviceAndRepairingUnitOfWork.ServiceAndRrepairing.Remove(entity);
            return _serviceAndRepairingUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<ServiceOrRepairing> entities)
        {
            _serviceAndRepairingUnitOfWork.ServiceAndRrepairing.RemoveRange(entities);
            return _serviceAndRepairingUnitOfWork.Complete();
        }
    }
}
