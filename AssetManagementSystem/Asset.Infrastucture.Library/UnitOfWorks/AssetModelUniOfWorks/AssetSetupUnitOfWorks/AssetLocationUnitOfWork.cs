using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetSetupUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetSetupRepositories;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks
{
    public class AssetLocationUnitOfWork : IAssetLocationUnitOfWork
    {
        private readonly AssetDbContext _context;
        public AssetLocationUnitOfWork(AssetDbContext context)
        {
            _context = context;
            AssetLocation = new AssetLocationRepository(_context);
        }

        public IAssetLocationRepository AssetLocation { get; set; }     

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
