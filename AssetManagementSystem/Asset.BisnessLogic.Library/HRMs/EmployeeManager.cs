using System.Collections.Generic;
using Asset.DataAccess.Library.Hrs;
using Asset.Models.Library.EntityModels.HrModels;

namespace Asset.BisnessLogic.Library.HRMs
{
    public class EmployeeManager : IRepositoryManager<Employee>
    {
        private readonly EmployeeGetway _employeeGetway;
        public EmployeeManager()
        {
            _employeeGetway = new EmployeeGetway();
        }


        public bool IsFirstNameExist(string firstName)
        {
            bool isFrstName = false;
            var employee = GetEmployeeByFirstName(firstName);
            if (employee != null)
            {
                isFrstName = true;
            }
            return isFrstName;
        }

        private Employee GetEmployeeByFirstName(string firstName)
        {
            return _employeeGetway.GetEmployeeByFirstName(firstName);
        }


        public bool IsLastNameExist(string lastName)
        {
            bool isLastName = false;
            var employee = GetEmployeeByLastName(lastName);
            if (employee != null)
            {
                isLastName = true;
            }
            return isLastName;
        }

        private Employee GetEmployeeByLastName(string lastName)
        {
            return _employeeGetway.GetEmployeeByLastName(lastName);
        }

        public bool IsEmailExist(string email)
        {
            bool isEmail = false;
            var employee = GetEmployeeByEmail(email);
            if (employee != null)
            {
                isEmail = true;
            }
            return isEmail;
        }

        private Employee GetEmployeeByEmail(string email)
        {
            return _employeeGetway.GetEmployeeByEmail(email);
        }

        public bool IsEmployeeCodeExist(string code)
        {
            bool isEmployeeCode = false;
            var employee = GetEmployeeByEmployeeCode(code);
            if (employee != null)
            {
                isEmployeeCode = true;
            }
            return isEmployeeCode;
        }

        private Employee GetEmployeeByEmployeeCode(string code)
        {
            return _employeeGetway.GetEmployeeByEmployeeCode(code);
        }

        public IEnumerable<Employee> EmployeesWithOrganizationBrnachDepartmentAndDdesignation()
        {
            return _employeeGetway.EmployeesWithOrganizationBrnachDepartmentAndDdesignation();
        }

        public IEnumerable<Employee> FindById(int id)
        {
            return _employeeGetway.Find(id);
        }

        public Employee SingleEmployee(int id)
        {
            return _employeeGetway.SingleEmployee(id);
        }



        public Employee Get(int id)
        {
            return _employeeGetway.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeGetway.GetAll();
        }

        public int Add(Employee entity)
        {
            return _employeeGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Employee> entities)
        {
            return _employeeGetway.AddRange(entities);
        }

        public int Update(Employee entity)
        {
            return _employeeGetway.Update(entity);
        }

        public int Remove(Employee entity)
        {
            return _employeeGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Employee> entities)
        {
            return _employeeGetway.RemoveRange(entities);
        }
    }
}
