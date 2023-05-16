namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SellRev : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellerReviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Sname = c.String(maxLength: 128),
                        Id = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 15),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Sellers", t => t.Sname)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Sname)
                .Index(t => t.Id);
            
            AddColumn("dbo.Sellers", "SellerReview_ReviewId", c => c.Int());
            CreateIndex("dbo.Sellers", "SellerReview_ReviewId");
            AddForeignKey("dbo.Sellers", "SellerReview_ReviewId", "dbo.SellerReviews", "ReviewId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellerReviews", "Id", "dbo.Users");
            DropForeignKey("dbo.Sellers", "SellerReview_ReviewId", "dbo.SellerReviews");
            DropForeignKey("dbo.SellerReviews", "Sname", "dbo.Sellers");
            DropIndex("dbo.SellerReviews", new[] { "Id" });
            DropIndex("dbo.SellerReviews", new[] { "Sname" });
            DropIndex("dbo.Sellers", new[] { "SellerReview_ReviewId" });
            DropColumn("dbo.Sellers", "SellerReview_ReviewId");
            DropTable("dbo.SellerReviews");
        }
    }
}
