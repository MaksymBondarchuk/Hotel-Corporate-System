namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialClients3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "HasPhoto", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "HasPhoto");
        }
    }
}
