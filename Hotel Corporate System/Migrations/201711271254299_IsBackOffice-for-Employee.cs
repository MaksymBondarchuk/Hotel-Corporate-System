namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsBackOfficeforEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Occupations", "IsBackOffice", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Occupations", "IsBackOffice");
        }
    }
}
