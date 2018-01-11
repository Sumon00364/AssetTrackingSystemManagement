using System.Collections.Generic;
using Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;

namespace Asset.BisnessLogic.Library.AssetModelManagers.AssetEntryManagers
{
    public class FinanceManager : IRepositoryManager<Finance>
    {
        private readonly FinanceGetway _financeGetway;
        public FinanceManager()
        {
            _financeGetway = new FinanceGetway();
        }


        public Finance Get(int id)
        {
            return _financeGetway.Get(id);
        }

        public IEnumerable<Finance> GetAll()
        {
            return _financeGetway.GetAll();
        }

        public int Add(Finance entity)
        {
            return _financeGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Finance> entities)
        {
            return _financeGetway.AddRange(entities);
        }

        public int Update(Finance entity)
        {
            return _financeGetway.Update(entity);
        }

        public int Remove(Finance entity)
        {
            return _financeGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Finance> entities)
        {
            return _financeGetway.RemoveRange(entities);
        }
    }
}
