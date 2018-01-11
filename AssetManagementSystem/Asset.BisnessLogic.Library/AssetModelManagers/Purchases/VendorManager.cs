using System.Collections.Generic;
using Asset.DataAccess.Library.Purchases;
using Asset.Models.Library.EntityModels.Purchases;

namespace Asset.BisnessLogic.Library.AssetModelManagers.Purchases
{
    public class VendorManager : IRepositoryManager<Vendor>
    {
        private readonly VendorGetway _vendorGetway;
        public VendorManager()
        {
            _vendorGetway = new VendorGetway();
        }


        public bool IsVendorNAmeExist(string name)
        {
            bool isName = false;
            var vendorName = GetVendorByName(name);
            if (vendorName != null)
            {
                isName = true;
            }
            return isName;
        }

        private Vendor GetVendorByName(string name)
        {
            return _vendorGetway.GetVendorByName(name);
        }

        public bool IsVendorShortName(string shortName)
        {
            bool isShortName = false;
            var vendorShortName = GetVendorByShortName(shortName);
            if (vendorShortName != null)
            {
                isShortName = true;
            }
            return isShortName;
        }

        private Vendor GetVendorByShortName(string shortName)
        {
            return _vendorGetway.GetVendorByShortName(shortName);
        }

        public bool IsContactNoExist(string number)
        {
            bool isContactNo = false;
            var contactNumber = GetVendorByContactNo(number);
            if (contactNumber != null)
            {
                isContactNo = true;
            }
            return isContactNo;
        }

        private Vendor GetVendorByContactNo(string number)
        {
            return _vendorGetway.GetVendorByContactNo(number);
        }

        public bool IsVendorEmailExist(string email)
        {
            bool isEmail = false;
            var vendorEmail = GetVendorByEmail(email);
            if (vendorEmail != null)
            {
                isEmail = true;
            }
            return isEmail;
        }

        private Vendor GetVendorByEmail(string email)
        {
            return _vendorGetway.GetVendorByEmail(email);
        }



        public IEnumerable<Vendor> FindById(int id)
        {
            return _vendorGetway.Find(id);
        }

        public Vendor SingleVendor(int id)
        {
            return _vendorGetway.SingleVendor(id);
        }




        public Vendor Get(int id)
        {
            return _vendorGetway.Get(id);
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _vendorGetway.GetAll();
        }

        public int Add(Vendor entity)
        {
            return _vendorGetway.Add(entity);
        }

        public int AddRange(IEnumerable<Vendor> entities)
        {
            return _vendorGetway.AddRange(entities);
        }

        public int Update(Vendor entity)
        {
            return _vendorGetway.Update(entity);
        }

        public int Remove(Vendor entity)
        {
            return _vendorGetway.Remove(entity);
        }

        public int RemoveRange(IEnumerable<Vendor> entities)
        {
            return _vendorGetway.RemoveRange(entities);
        }
    }
}
