using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.DataAccess.Library.AssetModelGetways.AssetEntryGetways
{
    public class FinanceGetway : IRepositoryGetway<Finance>
    {
        private readonly FinanceUnitOfWork _financeUnitOfWork;
        public FinanceGetway()
        {
            _financeUnitOfWork = new FinanceUnitOfWork(new AssetDbContext());
        }


        public Finance Get(int id)
        {
            return _financeUnitOfWork.Finance.Get(id);
        }

        public IEnumerable<Finance> GetAll()
        {
            return _financeUnitOfWork.Finance.GetAll();
        }

        public int Add(Finance entity)
        {
            _financeUnitOfWork.Finance.Add(entity);
            return _financeUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Finance> entities)
        {
            _financeUnitOfWork.Finance.AddRange(entities);
            return _financeUnitOfWork.Complete();
        }

        public int Update(Finance entity)
        {
            _financeUnitOfWork.Finance.Update(entity);
            return _financeUnitOfWork.Complete();
        }

        public int Remove(Finance entity)
        {
            _financeUnitOfWork.Finance.Remove(entity);
            return _financeUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Finance> entities)
        {
            _financeUnitOfWork.Finance.RemoveRange(entities);
            return _financeUnitOfWork.Complete();
        }
    }
}
