namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRolesforEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "OccupationId", "dbo.Occupations");
            DropIndex("dbo.Employees", new[] { "OccupationId" });
            AddColumn("dbo.Employees", "Roles", c => c.String());
            DropColumn("dbo.Employees", "OccupationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "OccupationId", c => c.Guid(nullable: false));
            DropColumn("dbo.Employees", "Roles");
            CreateIndex("dbo.Employees", "OccupationId");
            AddForeignKey("dbo.Employees", "OccupationId", "dbo.Occupations", "Id", cascadeDelete: true);
        }
    }
}
