using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetSetups;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetSetupUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetSetupRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetSetupUnitOfWorks
{
    public class AssetGroupUnitOfWork : IAssetGroupUnitOfWork
    {
        private readonly AssetDbContext _context;
        public AssetGroupUnitOfWork(AssetDbContext context)
        {
            _context = context;
            AssetGroup = new AssetGroupRepository(_context);
        }


        public IAssetGroupRepository AssetGroup { get; set; }

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
