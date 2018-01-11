using Asset.Core.Repository.Library.Repositorys.HrModels;
using Asset.Core.Repository.Library.UnitOfWorks.HRMs;
using AssetSqlDatabase.Library.DatabaseContext;
using Asset.Infrastucture.Library.Repositorys.Hrs;

namespace Asset.Infrastucture.Library.UnitOfWorks.HRMs
{
    public class HrUnitOfWork : IHrUnitOfWork
    {
        private readonly AssetDbContext _context;


        public HrUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Employee = new EmployeeRepository(_context);
        }

        public IEmployeeRepository Employee { get; set; }


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
