namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "Notes");
        }
    }
}
