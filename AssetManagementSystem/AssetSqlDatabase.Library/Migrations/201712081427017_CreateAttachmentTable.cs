namespace AssetSqlDatabase.Library.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateAttachmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attchments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryId = c.Int(nullable: false),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .Index(t => t.AssetEntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attchments", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.Attchments", new[] { "AssetEntryId" });
            DropTable("dbo.Attchments");
        }
    }
}
