namespace AfterMarketStocks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedBuySellTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuySells", "buy", c => c.String());
            AddColumn("dbo.BuySells", "sell", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BuySells", "sell");
            DropColumn("dbo.BuySells", "buy");
        }
    }
}
