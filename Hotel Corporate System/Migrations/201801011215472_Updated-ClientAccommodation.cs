namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClientAccommodation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientAccommodations", "BillId", c => c.Guid());
            CreateIndex("dbo.ClientAccommodations", "BillId");
            AddForeignKey("dbo.ClientAccommodations", "BillId", "dbo.Bills", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientAccommodations", "BillId", "dbo.Bills");
            DropIndex("dbo.ClientAccommodations", new[] { "BillId" });
            DropColumn("dbo.ClientAccommodations", "BillId");
        }
    }
}
