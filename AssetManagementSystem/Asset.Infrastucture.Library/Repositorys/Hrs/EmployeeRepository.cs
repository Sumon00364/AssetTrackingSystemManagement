using System.Collections.Generic;
using Asset.Core.Repository.Library.Repositorys.HrModels;
using Asset.Models.Library.EntityModels.HrModels;
using Core.Repository.Library.Infrastucture;
using System.Data.Entity;
using System.Linq;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.Repositorys.Hrs
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {
        }

        public AssetDbContext AssetDbContext
        {
            get
            {
                return Context as AssetDbContext;
            }
        }

        public Employee GetEmployeeByFirstName(string firstName)
        {
            var employee = AssetDbContext.Employees.SingleOrDefault(e => e.FirstName == firstName);
            return employee;
        }

        public Employee GetEmployeeByLastName(string lastName)
        {
            var employee = AssetDbContext.Employees.SingleOrDefault(e => e.LastName == lastName);
            return employee;
        }

        public Employee GetEmployeeByEmail(string email)
        {
            var employee = AssetDbContext.Employees.SingleOrDefault(e => e.Email == email);
            return employee;
        }

        public Employee GetEmployeeByEmployeeCode(string code)
        {
            var employee = AssetDbContext.Employees.SingleOrDefault(e => e.Code == code);
            return employee;
        }

        public IEnumerable<Employee> EmployeesWithOrganizationBrnachDepartmentAndDdesignation()
        {
            var employee = AssetDbContext.Employees.Include(o => o.Organization).Include(b => b.Branch)
                .Include(d => d.Department).Include(ds => ds.Designation);
            return employee;
        }
    }
}
