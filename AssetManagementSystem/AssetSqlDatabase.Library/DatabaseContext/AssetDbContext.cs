using Asset.Models.Library.EntityModels.OrganizationModels;
using System.Data.Entity;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using Asset.Models.Library.EntityModels.HrModels;
using Asset.Models.Library.EntityModels.Purchases;

namespace AssetSqlDatabase.Library.DatabaseContext
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext()
            :base("AssetDefaultConnection")
        {
            
        }
        //Organizations Set-Up
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        
           

        //Purchases set-up.....
        public virtual DbSet<Vendor> Vendors { get; set; }  



        //HRM Set-up
        public virtual DbSet<Employee> Employees { get; set; }  

        
        //Asset Set-up
        public virtual DbSet<AssetType> AssetTypes { get; set; }
        public virtual DbSet<AssetGroup> AssetGroups { get; set; }
        public virtual DbSet<AssetLocation> AssetLocations { get; set; }
        public virtual DbSet<AssetManufacurer> AssetManufacurers { get; set; }
        public virtual DbSet<AssetModel> AssetModels { get; set; }   

        //Asset-Entry Setup
        public virtual DbSet<AssetEntry> AssetEntries { get; set; }
        public virtual DbSet<Attchment> Attchments { get; set; }
        public virtual DbSet<Finance> Finances { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<ServiceOrRepairing> ServiceOrRepairings { get; set; }    
    }
}
