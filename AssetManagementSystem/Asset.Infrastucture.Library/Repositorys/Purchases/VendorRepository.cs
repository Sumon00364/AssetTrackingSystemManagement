using Asset.Core.Repository.Library.Repositorys.Purchases;
using Asset.Models.Library.EntityModels.Purchases;
using Core.Repository.Library.Infrastucture;
using System.Linq;
using System.Data.Entity;
using AssetSqlDatabase.Library.DatabaseContext;

namespace Asset.Infrastucture.Library.Repositorys.Purchases
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public VendorRepository(DbContext context)
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

        public Vendor GetVendorByName(string name)
        {
            var vendor = AssetDbContext.Vendors.SingleOrDefault(v => v.VendorName == name);
            return vendor;
        }

        public Vendor GetVendorByShortName(string shortName)
        {
            var vendor = AssetDbContext.Vendors.SingleOrDefault(v => v.VendorShortName == shortName);
            return vendor;
        }

        public Vendor GetVendorByContactNo(string number)
        {
            var vendor = AssetDbContext.Vendors.SingleOrDefault(v => v.ContactNo == number);
            return vendor;
        }

        public Vendor GetVendorByEmail(string email)
        {
            var vendor = AssetDbContext.Vendors.SingleOrDefault(v => v.Email == email);
            return vendor;
        }
    }
}
