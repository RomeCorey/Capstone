namespace AfterMarketStocks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModelTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuySells", "userStock", c => c.String());
            AddColumn("dbo.BuySells", "currentPrice", c => c.Single(nullable: false));
            AddColumn("dbo.MyStocks", "stock", c => c.String());
            AddColumn("dbo.MyStocks", "currentPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyStocks", "currentPrice");
            DropColumn("dbo.MyStocks", "stock");
            DropColumn("dbo.BuySells", "currentPrice");
            DropColumn("dbo.BuySells", "userStock");
        }
    }
}
