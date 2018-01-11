using Asset.Models.Library.EntityModels.Purchases;
using AssetSqlDatabase.Library.DatabaseContext;
using System.Collections.Generic;
using Asset.Infrastucture.Library.UnitOfWorks.Purchases;

namespace Asset.DataAccess.Library.Purchases
{
    public class VendorGetway : IRepositoryGetway<Vendor>
    {
        private readonly PurchaseUnitOfWork _purchaseUnitOfWork;

        public VendorGetway()
        {
            _purchaseUnitOfWork = new PurchaseUnitOfWork(new AssetDbContext());
        }

        public int Add(Vendor entity)
        {
            _purchaseUnitOfWork.Vendors.Add(entity);
            return _purchaseUnitOfWork.Complete();
        }

        public int AddRange(IEnumerable<Vendor> entities)
        {
            _purchaseUnitOfWork.Vendors.AddRange(entities);
            return _purchaseUnitOfWork.Complete();
        }

        public Vendor Get(int id)
        {
            return _purchaseUnitOfWork.Vendors.Get(id);
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _purchaseUnitOfWork.Vendors.GetAll();
        }

        public int Remove(Vendor entity)
        {
            _purchaseUnitOfWork.Vendors.Remove(entity);
            return _purchaseUnitOfWork.Complete();
        }

        public int RemoveRange(IEnumerable<Vendor> entities)
        {
            _purchaseUnitOfWork.Vendors.RemoveRange(entities);
            return _purchaseUnitOfWork.Complete();
        }

        public int Update(Vendor entity)
        {
            _purchaseUnitOfWork.Vendors.Update(entity);
            return _purchaseUnitOfWork.Complete();
        }

        public Vendor GetVendorByName(string name)
        {
            return _purchaseUnitOfWork.Vendors.GetVendorByName(name);
        }

        public Vendor GetVendorByShortName(string shortName)
        {
            return _purchaseUnitOfWork.Vendors.GetVendorByShortName(shortName);
        }

        public Vendor GetVendorByContactNo(string number)
        {
            return _purchaseUnitOfWork.Vendors.GetVendorByContactNo(number);
        }

        public Vendor GetVendorByEmail(string email)
        {
            return _purchaseUnitOfWork.Vendors.GetVendorByEmail(email);
        }

        public IEnumerable<Vendor> Find(int id)
        {
            return _purchaseUnitOfWork.Vendors.Find(v => v.Id == id);
        }

        public Vendor SingleVendor(int id)
        {
            return _purchaseUnitOfWork.Vendors.SingleOrDefault(v => v.Id == id);
        }
    }
}
