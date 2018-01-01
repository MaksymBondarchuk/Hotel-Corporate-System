namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedClientServiceBill : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "ClientId", "dbo.Clients");
            DropIndex("dbo.Bills", new[] { "ClientId" });
            AddColumn("dbo.ClientServices", "Comment", c => c.String());
            AddColumn("dbo.ClientServices", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientServices", "ActualAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ClientServices", "BillId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ClientServices", "BillId");
            AddForeignKey("dbo.ClientServices", "BillId", "dbo.Bills", "Id", cascadeDelete: true);
            DropColumn("dbo.Bills", "ClientId");
            DropColumn("dbo.ClientServices", "IsBooking");
            DropColumn("dbo.ClientServices", "Name");
            DropColumn("dbo.ClientServices", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientServices", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ClientServices", "Name", c => c.String());
            AddColumn("dbo.ClientServices", "IsBooking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bills", "ClientId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.ClientServices", "BillId", "dbo.Bills");
            DropIndex("dbo.ClientServices", new[] { "BillId" });
            DropColumn("dbo.ClientServices", "BillId");
            DropColumn("dbo.ClientServices", "ActualAmount");
            DropColumn("dbo.ClientServices", "Date");
            DropColumn("dbo.ClientServices", "Comment");
            CreateIndex("dbo.Bills", "ClientId");
            AddForeignKey("dbo.Bills", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
