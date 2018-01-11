using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Core.Repository.Library.UnitOfWorks.Organizations;
using Asset.Infrastucture.Library.Repositorys.Organizations;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.UnitOfWorks.Organizations
{
    public class DesignationUnitOfWork : IDesignationUnitOfWork
    {
        private readonly AssetDbContext _context;
        public DesignationUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Designation = new DesignationRepository(_context);
        }

        public IDesignationRepository Designation { get; set; }     

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
