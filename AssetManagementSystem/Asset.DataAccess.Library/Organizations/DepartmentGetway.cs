using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.Organizations;

namespace Asset.DataAccess.Library.Organizations
{
    public class DepartmentGetway : IRepositoryGetway<Department>
    {
        private readonly DepartmentUnitOfWork _departmentUnitOfWork;

        public DepartmentGetway()
        {
            _departmentUnitOfWork = new DepartmentUnitOfWork(new AssetDbContext());
        }
        public int Add(Department entity)
        {
            _departmentUnitOfWork.Department.Add(entity);
            return _departmentUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Department> entities)
        {
            _departmentUnitOfWork.Department.AddRange(entities);
            return _departmentUnitOfWork.Complete();
        }

        public Department Get(int id)
        {
            return _departmentUnitOfWork.Department.Get(id);

        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentUnitOfWork.Department.GetAll();
        }

        public int Remove(Department entity)
        {
            _departmentUnitOfWork.Department.Remove(entity);
            return _departmentUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Department> entities)
        {
            _departmentUnitOfWork.Department.RemoveRange(entities);
            return _departmentUnitOfWork.Complete();
        }

        public int Update(Department entity)
        {
            _departmentUnitOfWork.Department.Update(entity);
            return _departmentUnitOfWork.Complete();
        }

        public Department GetDepartmentByShortName(string shortName)
        {
            return _departmentUnitOfWork.Department.GetDepartmentByShortName(shortName);
        }

        public IEnumerable<Department> Find(int id)
        {
            return _departmentUnitOfWork.Department.Find(c => c.Id == id);
        }

        public Department SingleDepartment(int id)
        {
            return _departmentUnitOfWork.Department.SingleOrDefault(c => c.Id == id);
        }

        public Department GetDepartmentByName(string name)
        {
            return _departmentUnitOfWork.Department.GetDepartmentByName(name);
        }

        public Department GetDepartmentByCode(string code)
        {
            return _departmentUnitOfWork.Department.GetDepartmentByCode(code);
        }

        public IEnumerable<Department> DepartmentWithOrganization()
        {
            return _departmentUnitOfWork.Department.DepartmentWithOrganization();
        }
    }
}
