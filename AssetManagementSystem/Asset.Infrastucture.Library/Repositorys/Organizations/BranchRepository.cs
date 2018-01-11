using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Asset.Core.Repository.Library.Repositorys.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using Core.Repository.Library.Infrastucture;

namespace Asset.Infrastucture.Library.Repositorys.Organizations
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(AssetDbContext context)
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


        public Branch GetBranchByShortName(string shortName)
        {
            var branch = AssetDbContext.Branches.SingleOrDefault(c => c.ShortName == shortName);
            return branch;
        }

        public IEnumerable<Branch> GetBranchWithOrganization()
        {
            var branch = AssetDbContext.Branches.Include(b => b.Organization);
            return branch;
        }

        public Branch GetBranchByName(string name)
        {
            var branch = AssetDbContext.Branches.SingleOrDefault(b => b.Name == name);
            return branch;
        }

        public Branch GetBranchByCode(string code)
        {
            var branch = AssetDbContext.Branches.SingleOrDefault(b => b.BranchCode == code);
            return branch;
        }
    }
}
