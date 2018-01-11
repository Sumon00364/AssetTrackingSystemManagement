using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetSetupManagers
{
    public class AssetModelManager : IRepositoryManager<AssetModel>
    {
        public AssetModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AssetModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(AssetModel entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IEnumerable<AssetModel> entities)
        {
            throw new NotImplementedException();
        }

        public int Update(AssetModel entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(AssetModel entity)
        {
            throw new NotImplementedException();
        }

        public int RemoveRange(IEnumerable<AssetModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
