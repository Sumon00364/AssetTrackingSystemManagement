using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetEntryUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetEntryRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks
{
    public class FinanceUnitOfWork : IFinanceUnitOfWork
    {
        private readonly AssetDbContext _context;
        public FinanceUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Finance = new FinanceRepository(_context);
        }

        public IFinanceRepository Finance { get; set; }


        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
