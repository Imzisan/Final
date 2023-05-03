namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfix1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uname = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moderators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uname = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.Int(nullable: false),
                        AddedBy = c.Int(nullable: false),
                        AssignProductBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AddedBy, cascadeDelete: true)
                .ForeignKey("dbo.AssignProducts", t => t.AssignProductBy, cascadeDelete: true)
                .Index(t => t.AddedBy)
                .Index(t => t.AssignProductBy);
            
            CreateTable(
                "dbo.AssignProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductType = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
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
                        Uname = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 15),
                        DMR_id = c.Int(nullable: false),
                        rp_id = c.Int(nullable: false),
                        orinfo_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Uname)
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
                        u_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.u_id, cascadeDelete: true)
                .Index(t => t.u_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        uname = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        uid = c.Int(nullable: false),
                        pid = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.pid, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.uid, cascadeDelete: true)
                .Index(t => t.uid)
                .Index(t => t.pid);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 15),
                        ProductCategory = c.String(nullable: false, maxLength: 15),
                        ProductPrice = c.Int(nullable: false),
                        ProdcutQuantity = c.Int(nullable: false),
                        SelleingBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.SelleingBy)
                .Index(t => t.SelleingBy);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderType = c.String(),
                        OrderQuantity = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        SelleBy = c.String(maxLength: 128),
                        productby = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.productby, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SelleBy)
                .Index(t => t.SelleBy)
                .Index(t => t.productby);
            
            CreateTable(
                "dbo.orderinformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        or_id = c.Int(nullable: false),
                        User_Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.or_id, cascadeDelete: true)
                .ForeignKey("dbo.User_Order", t => t.User_Order_Id)
                .Index(t => t.or_id)
                .Index(t => t.User_Order_Id);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Oid = c.Int(nullable: false),
                        pid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Oid, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.pid, cascadeDelete: false)
                .Index(t => t.Oid)
                .Index(t => t.pid);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Sname = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 15),
                        PhoneNumber = c.String(nullable: false),
                        NidNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Sname);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        review = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        uid = c.Int(nullable: false),
                        pid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.pid, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.uid, cascadeDelete: true)
                .Index(t => t.uid)
                .Index(t => t.pid);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ReviewFeedBack = c.String(nullable: false, maxLength: 150),
                        rid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reviews", t => t.rid, cascadeDelete: true)
                .Index(t => t.rid);
            
            CreateTable(
                "dbo.User_Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Oid = c.Int(nullable: false),
                        Uid = c.Int(nullable: false),
                        PaymentBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Oid, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Uid, cascadeDelete: true)
                .Index(t => t.Oid)
                .Index(t => t.Uid);
            
            CreateTable(
                "dbo.SalesReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthName = c.String(),
                        TotalSales = c.Int(nullable: false),
                        ReportedBy = c.Int(nullable: false),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moderators", t => t.ReportedBy, cascadeDelete: true)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .Index(t => t.ReportedBy)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        SellerId = c.String(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesReports", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.SalesReports", "ReportedBy", "dbo.Moderators");
            DropForeignKey("dbo.Moderators", "AssignProductBy", "dbo.AssignProducts");
            DropForeignKey("dbo.DeliveryMen", "rp_id", "dbo.ReciveProducts");
            DropForeignKey("dbo.DeliveryMen", "orinfo_id", "dbo.orderinformations");
            DropForeignKey("dbo.DeliveryMen", "DMR_id", "dbo.DeliveryManReviews");
            DropForeignKey("dbo.DeliveryManReviews", "u_id", "dbo.Users");
            DropForeignKey("dbo.User_Order", "Uid", "dbo.Users");
            DropForeignKey("dbo.orderinformations", "User_Order_Id", "dbo.User_Order");
            DropForeignKey("dbo.User_Order", "Oid", "dbo.Orders");
            DropForeignKey("dbo.Carts", "uid", "dbo.Users");
            DropForeignKey("dbo.Products", "SelleingBy", "dbo.Sellers");
            DropForeignKey("dbo.Reviews", "uid", "dbo.Users");
            DropForeignKey("dbo.Reviews", "pid", "dbo.Products");
            DropForeignKey("dbo.FeedBacks", "rid", "dbo.Reviews");
            DropForeignKey("dbo.Orders", "SelleBy", "dbo.Sellers");
            DropForeignKey("dbo.ProductOrders", "pid", "dbo.Products");
            DropForeignKey("dbo.ProductOrders", "Oid", "dbo.Orders");
            DropForeignKey("dbo.Orders", "productby", "dbo.Products");
            DropForeignKey("dbo.orderinformations", "or_id", "dbo.Orders");
            DropForeignKey("dbo.Carts", "pid", "dbo.Products");
            DropForeignKey("dbo.ReciveProducts", "ap_id", "dbo.AssignProducts");
            DropForeignKey("dbo.Moderators", "AddedBy", "dbo.Admins");
            DropIndex("dbo.SalesReports", new[] { "Admin_Id" });
            DropIndex("dbo.SalesReports", new[] { "ReportedBy" });
            DropIndex("dbo.User_Order", new[] { "Uid" });
            DropIndex("dbo.User_Order", new[] { "Oid" });
            DropIndex("dbo.FeedBacks", new[] { "rid" });
            DropIndex("dbo.Reviews", new[] { "pid" });
            DropIndex("dbo.Reviews", new[] { "uid" });
            DropIndex("dbo.ProductOrders", new[] { "pid" });
            DropIndex("dbo.ProductOrders", new[] { "Oid" });
            DropIndex("dbo.orderinformations", new[] { "User_Order_Id" });
            DropIndex("dbo.orderinformations", new[] { "or_id" });
            DropIndex("dbo.Orders", new[] { "productby" });
            DropIndex("dbo.Orders", new[] { "SelleBy" });
            DropIndex("dbo.Products", new[] { "SelleingBy" });
            DropIndex("dbo.Carts", new[] { "pid" });
            DropIndex("dbo.Carts", new[] { "uid" });
            DropIndex("dbo.DeliveryManReviews", new[] { "u_id" });
            DropIndex("dbo.DeliveryMen", new[] { "orinfo_id" });
            DropIndex("dbo.DeliveryMen", new[] { "rp_id" });
            DropIndex("dbo.DeliveryMen", new[] { "DMR_id" });
            DropIndex("dbo.ReciveProducts", new[] { "ap_id" });
            DropIndex("dbo.Moderators", new[] { "AssignProductBy" });
            DropIndex("dbo.Moderators", new[] { "AddedBy" });
            DropTable("dbo.Tokens");
            DropTable("dbo.SalesReports");
            DropTable("dbo.User_Order");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.Reviews");
            DropTable("dbo.Sellers");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.orderinformations");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            DropTable("dbo.Users");
            DropTable("dbo.DeliveryManReviews");
            DropTable("dbo.DeliveryMen");
            DropTable("dbo.ReciveProducts");
            DropTable("dbo.AssignProducts");
            DropTable("dbo.Moderators");
            DropTable("dbo.Admins");
        }
    }
}
