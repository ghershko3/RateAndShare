namespace RateAndShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumOfStars = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        SongName = c.String(nullable: false, maxLength: 50),
                        ArtistName = c.String(maxLength: 100),
                        Genre = c.String(maxLength: 20),
                        YoutubeLink = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.SongId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "SongId", "dbo.Songs");
            DropIndex("dbo.Rates", new[] { "SongId" });
            DropTable("dbo.Songs");
            DropTable("dbo.Rates");
        }
    }
}
