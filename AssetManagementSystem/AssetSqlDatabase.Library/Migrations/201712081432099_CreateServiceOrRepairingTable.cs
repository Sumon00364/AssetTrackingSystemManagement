namespace AssetSqlDatabase.Library.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateServiceOrRepairingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceOrRepairings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryId = c.Int(nullable: false),
                        Description = c.String(),
                        ServiceDate = c.DateTime(),
                        ServiceingCostDecimal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartsCostDecimal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxDecimal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .Index(t => t.AssetEntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceOrRepairings", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.ServiceOrRepairings", new[] { "AssetEntryId" });
            DropTable("dbo.ServiceOrRepairings");
        }
    }
}
