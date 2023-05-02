namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductType = c.String(),
                        DeliveryDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReciveProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ap_id = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AssignProducts", t => t.ap_id, cascadeDelete: true)
                .Index(t => t.ap_id);
            
            CreateTable(
                "dbo.DeliveryMen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uname = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 15),
                        DMR_id = c.Int(nullable: false),
                        rp_id = c.Int(nullable: false),
                        orinfo_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryManReviews", t => t.DMR_id, cascadeDelete: true)
                .ForeignKey("dbo.orderinformations", t => t.orinfo_id, cascadeDelete: true)
                .ForeignKey("dbo.ReciveProducts", t => t.rp_id, cascadeDelete: true)
                .Index(t => t.DMR_id)
                .Index(t => t.rp_id)
                .Index(t => t.orinfo_id);
            
            CreateTable(
                "dbo.DeliveryManReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        review = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.orderinformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeliveryMen", "rp_id", "dbo.ReciveProducts");
            DropForeignKey("dbo.DeliveryMen", "orinfo_id", "dbo.orderinformations");
            DropForeignKey("dbo.DeliveryMen", "DMR_id", "dbo.DeliveryManReviews");
            DropForeignKey("dbo.ReciveProducts", "ap_id", "dbo.AssignProducts");
            DropIndex("dbo.DeliveryMen", new[] { "orinfo_id" });
            DropIndex("dbo.DeliveryMen", new[] { "rp_id" });
            DropIndex("dbo.DeliveryMen", new[] { "DMR_id" });
            DropIndex("dbo.ReciveProducts", new[] { "ap_id" });
            DropTable("dbo.orderinformations");
            DropTable("dbo.DeliveryManReviews");
            DropTable("dbo.DeliveryMen");
            DropTable("dbo.ReciveProducts");
            DropTable("dbo.AssignProducts");
        }
    }
}
