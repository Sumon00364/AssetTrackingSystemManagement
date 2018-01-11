namespace AssetSqlDatabase.Library.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateAssetModelTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetGroupId = c.Int(nullable: false),
                        AssetManufacurerId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetGroups", t => t.AssetGroupId, cascadeDelete: true)
                .ForeignKey("dbo.AssetManufacurers", t => t.AssetManufacurerId)
                .Index(t => t.AssetGroupId)
                .Index(t => t.AssetManufacurerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetModels", "AssetManufacurerId", "dbo.AssetManufacurers");
            DropForeignKey("dbo.AssetModels", "AssetGroupId", "dbo.AssetGroups");
            DropIndex("dbo.AssetModels", new[] { "AssetManufacurerId" });
            DropIndex("dbo.AssetModels", new[] { "AssetGroupId" });
            DropTable("dbo.AssetModels");
        }
    }
}
