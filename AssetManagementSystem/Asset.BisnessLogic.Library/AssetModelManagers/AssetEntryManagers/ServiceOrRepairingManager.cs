using System.Collections.Generic;
using Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetEntryManagers
{
    public class ServiceOrRepairingManager : IRepositoryManager<ServiceOrRepairing>
    {
        private readonly ServiceAndRepairingGetway _serviceAndRepairingGetway;
        public ServiceOrRepairingManager()
        {
            _serviceAndRepairingGetway = new ServiceAndRepairingGetway();
        }


        public ServiceOrRepairing Get(int id)
        {
            return _serviceAndRepairingGetway.Get(id);
        }

        public IEnumerable<ServiceOrRepairing> GetAll()
        {
            return _serviceAndRepairingGetway.GetAll();
        }

        public int Add(ServiceOrRepairing entity)
        {
            return _serviceAndRepairingGetway.Add(entity);
        }

        public int AddRange(IEnumerable<ServiceOrRepairing> entities)
        {
            return _serviceAndRepairingGetway.AddRange(entities);
        }

        public int Update(ServiceOrRepairing entity)
        {
            return _serviceAndRepairingGetway.Update(entity);
        }

        public int Remove(ServiceOrRepairing entity)
        {
            return _serviceAndRepairingGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<ServiceOrRepairing> entities)
        {
            return _serviceAndRepairingGetway.RemoveRange(entities);
        }
    }
}
