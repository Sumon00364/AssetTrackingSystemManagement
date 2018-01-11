using Asset.Core.Repository.Library.Repositorys.Organizations;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks.Organizations
{
    public interface IDepartmentUnitOfWork : IUnitOfWork
    {
        IDepartmentRepository Department { get; set; }
    }
}
