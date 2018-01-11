using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Core.Repository.Library.UnitOfWorks.Organizations;
using AssetSqlDatabase.Library.DatabaseContext;
using Asset.Infrastucture.Library.Repositorys.Organizations;

namespace Asset.Infrastucture.Library.UnitOfWorks.Organizations
{
    public class DepartmentUnitOfWork : IDepartmentUnitOfWork
    {
        private readonly AssetDbContext _context;
        public DepartmentUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Department = new DepartmentRepository(_context);
        }
        public IDepartmentRepository Department { get; set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
