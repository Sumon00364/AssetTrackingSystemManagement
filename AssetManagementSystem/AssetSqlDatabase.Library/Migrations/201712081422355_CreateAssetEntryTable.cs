namespace AssetSqlDatabase.Library.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateAssetEntryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        AssetLocationId = c.Int(nullable: false),
                        AssetTypeId = c.Int(nullable: false),
                        AssetGroupId = c.Int(nullable: false),
                        AssetManufacurerId = c.Int(nullable: false),
                        AssetModelId = c.Int(nullable: false),
                        AssetId = c.String(),
                        Name = c.String(),
                        SerialNo = c.String(),
                        Status = c.Boolean(nullable: false),
                        Attachment = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetGroups", t => t.AssetGroupId, cascadeDelete: true)
                .ForeignKey("dbo.AssetLocations", t => t.AssetLocationId, cascadeDelete: true)
                .ForeignKey("dbo.AssetManufacurers", t => t.AssetManufacurerId)
                .ForeignKey("dbo.AssetModels", t => t.AssetModelId)
                .ForeignKey("dbo.AssetTypes", t => t.AssetTypeId)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.OrganizationId)
                .Index(t => t.BranchId)
                .Index(t => t.AssetLocationId)
                .Index(t => t.AssetTypeId)
                .Index(t => t.AssetGroupId)
                .Index(t => t.AssetManufacurerId)
                .Index(t => t.AssetModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetEntries", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.AssetEntries", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.AssetEntries", "AssetTypeId", "dbo.AssetTypes");
            DropForeignKey("dbo.AssetEntries", "AssetModelId", "dbo.AssetModels");
            DropForeignKey("dbo.AssetEntries", "AssetManufacurerId", "dbo.AssetManufacurers");
            DropForeignKey("dbo.AssetEntries", "AssetLocationId", "dbo.AssetLocations");
            DropForeignKey("dbo.AssetEntries", "AssetGroupId", "dbo.AssetGroups");
            DropIndex("dbo.AssetEntries", new[] { "AssetModelId" });
            DropIndex("dbo.AssetEntries", new[] { "AssetManufacurerId" });
            DropIndex("dbo.AssetEntries", new[] { "AssetGroupId" });
            DropIndex("dbo.AssetEntries", new[] { "AssetTypeId" });
            DropIndex("dbo.AssetEntries", new[] { "AssetLocationId" });
            DropIndex("dbo.AssetEntries", new[] { "BranchId" });
            DropIndex("dbo.AssetEntries", new[] { "OrganizationId" });
            DropTable("dbo.AssetEntries");
        }
    }
}
