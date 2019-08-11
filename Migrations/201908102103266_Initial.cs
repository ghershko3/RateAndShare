namespace RateAndShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rates", "SongId", "dbo.Songs");
            DropPrimaryKey("dbo.Songs");
            DropColumn("dbo.Songs", "SongId");
            AddColumn("dbo.Songs", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Songs", "SongName", c => c.String());
            AlterColumn("dbo.Songs", "ArtistName", c => c.String());
            AlterColumn("dbo.Songs", "Genre", c => c.String());
            AlterColumn("dbo.Songs", "YoutubeLink", c => c.String());
            AddPrimaryKey("dbo.Songs", "ID");
            AddForeignKey("dbo.Rates", "SongId", "dbo.Songs", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "SongId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Rates", "SongId", "dbo.Songs");
            DropPrimaryKey("dbo.Songs");
            AlterColumn("dbo.Songs", "YoutubeLink", c => c.String(maxLength: 30));
            AlterColumn("dbo.Songs", "Genre", c => c.String(maxLength: 20));
            AlterColumn("dbo.Songs", "ArtistName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Songs", "SongName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Songs", "ID");
            AddPrimaryKey("dbo.Songs", "SongId");
            AddForeignKey("dbo.Rates", "SongId", "dbo.Songs", "SongId", cascadeDelete: true);
        }
    }
}
