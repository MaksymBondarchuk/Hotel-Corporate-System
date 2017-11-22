namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "Number", c => c.String());
        }
    }
}
