using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetEntryUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetEntryRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks
{
    public class ServiceAndRepairingUnitOfWork : IServicceAndRepairingUnitOfWork
    {
        private readonly AssetDbContext _context;
        public ServiceAndRepairingUnitOfWork(AssetDbContext context)
        {
            _context = context;
            ServiceAndRrepairing = new ServiceAndRepairingRepository(_context);
        }

        public IServiceOrRepairingRepository ServiceAndRrepairing { get; set; }


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
