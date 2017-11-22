namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialClients5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "HasPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "HasPhoto", c => c.Boolean(nullable: false));
        }
    }
}
