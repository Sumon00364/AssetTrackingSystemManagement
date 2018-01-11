using Asset.Core.Repository.Library.Repositorys.Purchases;
using Core.Repository.Library.UnitOfWork;

namespace Asset.Core.Repository.Library.UnitOfWorks.Purchases
{
    public interface IPurchaseUnitOfWork:IUnitOfWork
    {
        IVendorRepository Vendors { get; set; }
    }
}
