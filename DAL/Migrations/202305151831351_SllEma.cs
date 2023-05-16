namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SllEma : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sellers", "Email", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sellers", "Email", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
