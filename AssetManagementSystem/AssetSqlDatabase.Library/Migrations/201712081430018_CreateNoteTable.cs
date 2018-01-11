namespace AssetSqlDatabase.Library.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateNoteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: true)
                .Index(t => t.AssetEntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.Notes", new[] { "AssetEntryId" });
            DropTable("dbo.Notes");
        }
    }
}
