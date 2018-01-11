namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAssetLocationPropertyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetLocations", "AssetLocationCode", c => c.String());
            DropColumn("dbo.AssetLocations", "BranchCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssetLocations", "BranchCode", c => c.String());
            DropColumn("dbo.AssetLocations", "AssetLocationCode");
        }
    }
}
