using System.Data.Entity.Migrations;

namespace Hotel_Corporate_System.Migrations
{
    public partial class AllNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2)
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientAccommodations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsBooking = c.Boolean(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        RoomId = c.Guid(nullable: false),
                        BillId = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.RoomId)
                .Index(t => t.BillId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Birth = c.DateTime(nullable: false),
                        IsVip = c.Boolean(nullable: false)
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Class = c.Int(nullable: false),
                        Beds = c.Int(nullable: false),
                        Number = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        FloorId = c.Guid(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId, cascadeDelete: true)
                .Index(t => t.FloorId);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Number = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientServices",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Comment = c.String(),
                        Date = c.DateTime(nullable: false),
                        ActualAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Guid(nullable: false),
                        ServiceId = c.Guid(nullable: false),
                        BillId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ServiceId)
                .Index(t => t.BillId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2)
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Roles = c.String()
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InternalOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        OrderTypeId = c.Guid(nullable: false),
                        RequestedById = c.Guid(nullable: false),
                        AssignedToId = c.Guid(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AssignedToId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.RequestedById)
                .Index(t => t.OrderTypeId)
                .Index(t => t.RequestedById)
                .Index(t => t.AssignedToId);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        SupplyId = c.Guid(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supplies", t => t.SupplyId, cascadeDelete: true)
                .Index(t => t.SupplyId);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        QuantityAvailable = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsFrontOffice = c.Boolean(nullable: false),
                        IsBackOffice = c.Boolean(nullable: false)
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InternalOrders", "RequestedById", "dbo.Employees");
            DropForeignKey("dbo.InternalOrders", "OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.OrderTypes", "SupplyId", "dbo.Supplies");
            DropForeignKey("dbo.InternalOrders", "AssignedToId", "dbo.Employees");
            DropForeignKey("dbo.ClientServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ClientServices", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientServices", "BillId", "dbo.Bills");
            DropForeignKey("dbo.ClientAccommodations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.ClientAccommodations", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientAccommodations", "BillId", "dbo.Bills");
            DropIndex("dbo.OrderTypes", new[] { "SupplyId" });
            DropIndex("dbo.InternalOrders", new[] { "AssignedToId" });
            DropIndex("dbo.InternalOrders", new[] { "RequestedById" });
            DropIndex("dbo.InternalOrders", new[] { "OrderTypeId" });
            DropIndex("dbo.ClientServices", new[] { "BillId" });
            DropIndex("dbo.ClientServices", new[] { "ServiceId" });
            DropIndex("dbo.ClientServices", new[] { "ClientId" });
            DropIndex("dbo.Rooms", new[] { "FloorId" });
            DropIndex("dbo.ClientAccommodations", new[] { "BillId" });
            DropIndex("dbo.ClientAccommodations", new[] { "RoomId" });
            DropIndex("dbo.ClientAccommodations", new[] { "ClientId" });
            DropTable("dbo.Occupations");
            DropTable("dbo.Supplies");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.InternalOrders");
            DropTable("dbo.Employees");
            DropTable("dbo.Services");
            DropTable("dbo.ClientServices");
            DropTable("dbo.Floors");
            DropTable("dbo.Rooms");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientAccommodations");
            DropTable("dbo.Bills");
        }
    }
}
