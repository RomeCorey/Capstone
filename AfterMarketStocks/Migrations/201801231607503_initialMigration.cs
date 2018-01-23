namespace AfterMarketStocks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuySells",
                c => new
                    {
                        buySellId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.buySellId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuySells");
        }
    }
}
