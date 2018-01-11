namespace AssetSqlDatabase.Library.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateAssetManufactureTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetManufacurers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetGroupId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetGroups", t => t.AssetGroupId, cascadeDelete: true)
                .Index(t => t.AssetGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetManufacurers", "AssetGroupId", "dbo.AssetGroups");
            DropIndex("dbo.AssetManufacurers", new[] { "AssetGroupId" });
            DropTable("dbo.AssetManufacurers");
        }
    }
}
