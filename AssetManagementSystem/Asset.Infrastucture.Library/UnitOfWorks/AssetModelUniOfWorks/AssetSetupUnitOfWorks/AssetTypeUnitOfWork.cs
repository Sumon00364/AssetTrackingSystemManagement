using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetSetupUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetSetupRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks
{
    public class AssetTypeUnitOfWork : IAssetTypeUnitOfWork
    {
        private readonly AssetDbContext _context;
        public AssetTypeUnitOfWork(AssetDbContext context)
        {
            _context = context;
            AssetType = new AssetTypeRepository(_context);
        }

        public IAssetTypeRepository AssetType { get; set; }


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
