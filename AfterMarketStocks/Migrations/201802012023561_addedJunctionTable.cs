namespace AfterMarketStocks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedJunctionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserstockJunctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stock_buySellId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuySells", t => t.Stock_buySellId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Stock_buySellId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserstockJunctions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserstockJunctions", "Stock_buySellId", "dbo.BuySells");
            DropIndex("dbo.UserstockJunctions", new[] { "User_Id" });
            DropIndex("dbo.UserstockJunctions", new[] { "Stock_buySellId" });
            DropTable("dbo.UserstockJunctions");
        }
    }
}
