using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Core.Repository.Library.UnitOfWorks.Organizations;
using Asset.Infrastucture.Library.Repositorys.Organizations;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.Organizations
{
    public class BranchUnitOfWork : IBranchUnitOfWork
    {
        private readonly AssetDbContext _context;
        public BranchUnitOfWork(AssetDbContext contect)
        {
            _context = contect;
            Branch = new BranchRepository(_context);
        }

        public IBranchRepository Branch { get; set; }
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
