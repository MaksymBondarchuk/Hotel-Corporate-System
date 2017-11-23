namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientAccommodationDatesUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientAccommodations", "From", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientAccommodations", "To", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rooms", "Number", c => c.String());
            DropColumn("dbo.ClientAccommodations", "Begin");
            DropColumn("dbo.ClientAccommodations", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientAccommodations", "End", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientAccommodations", "Begin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rooms", "Number", c => c.String(nullable: false));
            DropColumn("dbo.ClientAccommodations", "To");
            DropColumn("dbo.ClientAccommodations", "From");
        }
    }
}
