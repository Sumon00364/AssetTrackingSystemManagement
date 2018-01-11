using System.Collections.Generic;
using Asset.Models.Library.EntityModels.HrModels;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.HrModels
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee GetEmployeeByFirstName(string firstName);
        Employee GetEmployeeByLastName(string lastName);
        Employee GetEmployeeByEmail(string email);
        Employee GetEmployeeByEmployeeCode(string code);    
        IEnumerable<Employee> EmployeesWithOrganizationBrnachDepartmentAndDdesignation();
    }
}
