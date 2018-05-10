namespace Craigslist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatetoListings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listings", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listings", "Date");
        }
    }
}
