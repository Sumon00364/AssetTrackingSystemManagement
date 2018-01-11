using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetEntryUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetEntryRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks
{
    public class AssetEntryUnitOfWork : IAssetEntryUnitOfWork
    {
        private readonly AssetDbContext _context;
        public AssetEntryUnitOfWork(AssetDbContext context)
        {
            _context = context;
            AssetEntry = new AssetEntryRepository(_context);
        }

        public IAssetEntryRepository AssetEntry { get; set; }


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
