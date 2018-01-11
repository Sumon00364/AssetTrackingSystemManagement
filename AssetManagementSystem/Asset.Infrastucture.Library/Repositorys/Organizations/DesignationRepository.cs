using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;

namespace Asset.Infrastucture.Library.Repositorys.Organizations
{
    public class DesignationRepository : Repository<Designation>,IDesignationRepository
    {
        public DesignationRepository(DbContext context) 
            : base(context)
        {
        }

        public AssetDbContext AssetDbContext
        {
            get
            {
                return Context as AssetDbContext;
            }
        }


        public Designation GetDesignationByName(string name)
        {
            var designation = AssetDbContext.Designations.SingleOrDefault(d => d.Name == name);
            return designation;
        }

        public Designation GetDesignationByShortName(string shortNme)
        {
            var designation = AssetDbContext.Designations.SingleOrDefault(d => d.ShortName == shortNme);
            return designation;
        }

        public IEnumerable<Designation> DesignationWithDepartment()
        {
            var designation = AssetDbContext.Designations.Include(d => d.Department);
            return designation;
        }
    }
}
