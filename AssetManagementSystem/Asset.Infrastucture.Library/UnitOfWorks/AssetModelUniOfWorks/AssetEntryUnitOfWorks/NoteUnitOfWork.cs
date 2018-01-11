using Asset.Core.Repository.Library.Repositorys.AssetsModels.AssetEntrys;
using Asset.Core.Repository.Library.UnitOfWorks.AssetModelUnitOfWorks.AssetEntryUnitOfWorks;
using Asset.Infrastucture.Library.Repositorys.AssetModelRepositories.AssetEntryRepositories;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.AssetModelUniOfWorks.AssetEntryUnitOfWorks
{
    public class NoteUnitOfWork : INoteUnitOfWork
    {
        private readonly AssetDbContext _context;
        public NoteUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Note = new NoteRepository(_context);
        }

        public INoteRepostiry Note { get; set; }


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
