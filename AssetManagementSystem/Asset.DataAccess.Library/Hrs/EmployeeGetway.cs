using Asset.Models.Library.EntityModels.HrModels;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.HRMs;

namespace Asset.DataAccess.Library.Hrs
{
    public class EmployeeGetway : IRepositoryGetway<Employee>
    {
        private readonly HrUnitOfWork _hrUnitOfWork;

        public EmployeeGetway()
        {
            _hrUnitOfWork = new HrUnitOfWork(new AssetDbContext());
        }


        public int Add(Employee entity)
        {
            _hrUnitOfWork.Employee.Add(entity);
            return _hrUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Employee> entities)
        {
            _hrUnitOfWork.Employee.AddRange(entities);
            return _hrUnitOfWork.Complete();
        }

        public Employee Get(int id)
        {
            return _hrUnitOfWork.Employee.Get(id);

        }

        public IEnumerable<Employee> GetAll()
        {
            return _hrUnitOfWork.Employee.GetAll();
        }

        public int Remove(Employee entity)
        {
            _hrUnitOfWork.Employee.Remove(entity);
            return _hrUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Employee> entities)
        {
            _hrUnitOfWork.Employee.RemoveRange(entities);
            return _hrUnitOfWork.Complete();
        }

        public int Update(Employee entity)
        {
            _hrUnitOfWork.Employee.Update(entity);
            return _hrUnitOfWork.Complete();
        }

        public Employee GetEmployeeByFirstName(string firstName)
        {
            return _hrUnitOfWork.Employee.GetEmployeeByFirstName(firstName);
        }

        public Employee GetEmployeeByLastName(string lastName)
        {
            return _hrUnitOfWork.Employee.GetEmployeeByLastName(lastName);
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _hrUnitOfWork.Employee.GetEmployeeByEmail(email);
        }

        public Employee GetEmployeeByEmployeeCode(string code)
        {
            return _hrUnitOfWork.Employee.GetEmployeeByEmployeeCode(code);
        }

        public IEnumerable<Employee> EmployeesWithOrganizationBrnachDepartmentAndDdesignation()
        {
            return _hrUnitOfWork.Employee.EmployeesWithOrganizationBrnachDepartmentAndDdesignation();
        }

        public IEnumerable<Employee> Find(int id)
        {
            return _hrUnitOfWork.Employee.Find(e => e.Id == id);
        }

        public Employee SingleEmployee(int id)
        {
            return _hrUnitOfWork.Employee.SingleOrDefault(e => e.Id == id);
        }
    }
}
