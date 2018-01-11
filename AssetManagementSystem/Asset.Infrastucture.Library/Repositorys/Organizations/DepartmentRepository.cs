using System.Collections.Generic;
using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using Core.Repository.Library.Infrastucture;
using System.Linq;
using System.Data.Entity;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.Repositorys.Organizations
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }

        public AssetDbContext AssetDbContext
        {
            get
            {
                return Context as AssetDbContext;
            }
        }



        public Department GetDepartmentByShortName(string shortName)
        { 
            var department = AssetDbContext.Departments.SingleOrDefault(c => c.ShortName == shortName);
            return department;
        }



        public Department GetDepartmentByName(string name)
        {
            var department = AssetDbContext.Departments.SingleOrDefault(d => d.Name == name);
            return department;
        }

        public Department GetDepartmentByCode(string code)
        {
            var department = AssetDbContext.Departments.SingleOrDefault(d => d.DepartmentCode == code);
            return department;
        }

        public IEnumerable<Department> DepartmentWithOrganization()
        {
            var department = AssetDbContext.Departments.Include(d => d.Organization);
            return department;
        }
    }
}
