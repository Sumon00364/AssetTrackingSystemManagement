using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetSetupUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetSetupRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks
{
    public class AssetManufacturerUnitOfWork : IAssetManufactureUnitOfWork
    {
        private readonly AssetDbContext _context;
        public AssetManufacturerUnitOfWork(AssetDbContext context)
        {
            _context = context;
            AssetManufacturer = new AssetManufacturerRepository(_context);
        }

        public IAssetManufacurerRepository AssetManufacturer { get; set; }


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
