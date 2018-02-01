namespace AfterMarketStocks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedBuySellStockTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuySells", "stock", c => c.String());
            DropColumn("dbo.BuySells", "userStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BuySells", "userStock", c => c.String());
            DropColumn("dbo.BuySells", "stock");
        }
    }
}
