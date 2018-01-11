namespace AssetSqlDatabase.Library.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateFinanceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Finances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        ParchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ParchaseOrderNo = c.String(),
                        PurchaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.AssetEntryId)
                .Index(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Finances", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Finances", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.Finances", new[] { "VendorId" });
            DropIndex("dbo.Finances", new[] { "AssetEntryId" });
            DropTable("dbo.Finances");
        }
    }
}
