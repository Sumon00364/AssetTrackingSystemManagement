using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetSetupUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetSetupRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks
{
    public class AssetModelUnitOfWork : IAssetModelUnitOfWork
    {
        private readonly AssetDbContext _context;
        public AssetModelUnitOfWork(AssetDbContext context)
        {
            _context = context;
            AssetModel = new AssetModelRepository(_context);
        }

        public IAssetModelRepository AssetModel { get; set; }


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
