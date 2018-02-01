namespace AfterMarketStocks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSymbolToBuySell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuySells", "symbol", c => c.String());
            AlterColumn("dbo.BuySells", "currentPrice", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BuySells", "currentPrice", c => c.Single(nullable: false));
            DropColumn("dbo.BuySells", "symbol");
        }
    }
}
