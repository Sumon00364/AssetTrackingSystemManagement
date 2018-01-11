using Asset.Models.Library.EntityModels.OrganizationModels;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.Organizations;

namespace Asset.DataAccess.Library.Organizations
{
    public class BranchGetway : IRepositoryGetway<Branch>
    {
        private readonly BranchUnitOfWork _branchUnitOfWork;

        public BranchGetway()
        {
            _branchUnitOfWork = new BranchUnitOfWork(new AssetDbContext());
        }
        public int Add(Branch entity)
        {
            _branchUnitOfWork.Branch.Add(entity);
            return _branchUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Branch> entities)
        {
            _branchUnitOfWork.Branch.AddRange(entities);
            return _branchUnitOfWork.Complete();
        }

        public Branch Get(int id)
        {
           return _branchUnitOfWork.Branch.Get(id);

        }

        public IEnumerable<Branch> GetAll()
        {
            return _branchUnitOfWork.Branch.GetAll();
        }

        public int Remove(Branch entity)
        {
            _branchUnitOfWork.Branch.Remove(entity);
            return _branchUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Branch> entities)
        {
            _branchUnitOfWork.Branch.RemoveRange(entities);
            return _branchUnitOfWork.Complete();
        }

        public int Update(Branch entity)
        {
            _branchUnitOfWork.Branch.Update(entity);
            return _branchUnitOfWork.Complete();
        }

        public Branch GetBranchByShortName(string shortName)
        {
            return _branchUnitOfWork.Branch.GetBranchByShortName(shortName);
        }

        public IEnumerable<Branch> Find(int id)
        {
            return _branchUnitOfWork.Branch.Find(c => c.Id == id);
        }

        public Branch SingleBranch(int id)
        {
            return _branchUnitOfWork.Branch.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Branch> GetBranchWithOrganization()
        {
            return _branchUnitOfWork.Branch.GetBranchWithOrganization();
        }

        public Branch GetBranchByName(string name)
        {
            return _branchUnitOfWork.Branch.GetBranchByName(name);
        }

        public Branch GetBranchByCode(string code)
        {
            return _branchUnitOfWork.Branch.GetBranchByCode(code);
        }
    }
}
