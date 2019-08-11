namespace RateAndShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 10),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Rates", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rates", "UserId");
            AddForeignKey("dbo.Rates", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "UserId", "dbo.Users");
            DropIndex("dbo.Rates", new[] { "UserId" });
            DropColumn("dbo.Rates", "UserId");
            DropTable("dbo.Users");
        }
    }
}
