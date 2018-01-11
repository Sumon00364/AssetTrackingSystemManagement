using Asset.Models.Library.EntityModels.Purchases;
using Core.Repository.Library.Core;

namespace Asset.Core.Repository.Library.Repositorys.Purchases
{
    public interface IVendorRepository:IRepository<Vendor>
    {
        Vendor GetVendorByName(string name);
        Vendor GetVendorByShortName(string shortName);
        Vendor GetVendorByContactNo(string number);
        Vendor GetVendorByEmail(string email);  
    }
}
