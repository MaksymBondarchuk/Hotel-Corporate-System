namespace Hotel_Corporate_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Birth = c.DateTime(nullable: false),
                        IsVip = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientAccommodations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsBooking = c.Boolean(nullable: false),
                        Begin = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        ClientId = c.Guid(nullable: false),
                        RoomId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Class = c.Int(nullable: false),
                        Beds = c.Int(nullable: false),
                        Number = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FloorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId, cascadeDelete: true)
                .Index(t => t.FloorId);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientServices",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsBooking = c.Boolean(nullable: false),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Guid(nullable: false),
                        ServiceId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ClientServices", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientAccommodations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.ClientAccommodations", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Bills", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientServices", new[] { "ServiceId" });
            DropIndex("dbo.ClientServices", new[] { "ClientId" });
            DropIndex("dbo.Rooms", new[] { "FloorId" });
            DropIndex("dbo.ClientAccommodations", new[] { "RoomId" });
            DropIndex("dbo.ClientAccommodations", new[] { "ClientId" });
            DropIndex("dbo.Bills", new[] { "ClientId" });
            DropTable("dbo.Services");
            DropTable("dbo.ClientServices");
            DropTable("dbo.Floors");
            DropTable("dbo.Rooms");
            DropTable("dbo.ClientAccommodations");
            DropTable("dbo.Clients");
            DropTable("dbo.Bills");
        }
    }
}
