namespace AfterMarketStocks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateToMyStocks : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MyStocks", "userName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyStocks", "userName", c => c.String());
        }
    }
}
