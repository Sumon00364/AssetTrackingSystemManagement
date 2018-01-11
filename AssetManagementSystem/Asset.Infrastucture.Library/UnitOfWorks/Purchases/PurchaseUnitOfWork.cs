﻿using Asset.Core.Repository.Library.Repositorys.Purchases;
using Asset.Core.Repository.Library.UnitOfWorks.Purchases;
using AssetSqlDatabase.Library.DatabaseContext;
using Asset.Infrastucture.Library.Repositorys.Purchases;

namespace Asset.Infrastucture.Library.UnitOfWorks.Purchases
{
    public class PurchaseUnitOfWork : IPurchaseUnitOfWork
    {
        private readonly AssetDbContext _context;

        public PurchaseUnitOfWork(AssetDbContext context)
        {
            _context = context;
            Vendors = new VendorRepository(context);
        }

        public IVendorRepository Vendors { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
