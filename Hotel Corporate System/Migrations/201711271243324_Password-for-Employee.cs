namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordforEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Password", c => c.String());
            AlterColumn("dbo.Rooms", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "Number", c => c.String());
            DropColumn("dbo.Employees", "Password");
        }
    }
}
