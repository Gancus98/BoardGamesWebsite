namespace BoardGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertisementModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        City = c.String(),
                        Description = c.String(),
                        MaxPlayer = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Author_ID = c.Int(),
                        BoardGame_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserModels", t => t.Author_ID)
                .ForeignKey("dbo.BoardGameModels", t => t.BoardGame_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.BoardGame_ID);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        Photo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contents = c.String(),
                        AuthorUserId = c.Int(nullable: false),
                        Author_ID = c.Int(),
                        Review_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserModels", t => t.Author_ID)
                .ForeignKey("dbo.ReviewModels", t => t.Review_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.Review_ID);
            
            CreateTable(
                "dbo.ReviewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Photo = c.String(),
                        Contents = c.String(),
                        DateOfPublication = c.DateTime(nullable: false),
                        Author_ID = c.Int(),
                        BoardGame_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserModels", t => t.Author_ID)
                .ForeignKey("dbo.BoardGameModels", t => t.BoardGame_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.BoardGame_ID);
            
            CreateTable(
                "dbo.BoardGameModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Designer = c.String(),
                        Publisher = c.String(),
                        NumberOfPlayers = c.String(),
                        RecommendedAge = c.Int(nullable: false),
                        GameTime = c.Int(nullable: false),
                        Description = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FriendModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        MyFollowers_ID = c.Int(nullable: false),
                        MyObservations_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserModels", t => t.MyFollowers_ID)
                .ForeignKey("dbo.UserModels", t => t.MyObservations_ID)
                .Index(t => t.MyFollowers_ID)
                .Index(t => t.MyObservations_ID);
            
            CreateTable(
                "dbo.MessageModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contents = c.String(),
                        IsDeleted = c.Boolean(),
                        PostDate = c.DateTime(nullable: false),
                        ReadDate = c.DateTime(),
                        ReceiverUser_ID = c.Int(nullable: false),
                        SenderUser_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserModels", t => t.ReceiverUser_ID)
                .ForeignKey("dbo.UserModels", t => t.SenderUser_ID)
                .Index(t => t.ReceiverUser_ID)
                .Index(t => t.SenderUser_ID);
            
            CreateTable(
                "dbo.PlayerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsConfirmed = c.Boolean(nullable: false),
                        Advertisement_ID = c.Int(),
                        Player_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AdvertisementModels", t => t.Advertisement_ID)
                .ForeignKey("dbo.UserModels", t => t.Player_ID)
                .Index(t => t.Advertisement_ID)
                .Index(t => t.Player_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertisementModels", "BoardGame_ID", "dbo.BoardGameModels");
            DropForeignKey("dbo.PlayerModels", "Player_ID", "dbo.UserModels");
            DropForeignKey("dbo.PlayerModels", "Advertisement_ID", "dbo.AdvertisementModels");
            DropForeignKey("dbo.MessageModels", "SenderUser_ID", "dbo.UserModels");
            DropForeignKey("dbo.MessageModels", "ReceiverUser_ID", "dbo.UserModels");
            DropForeignKey("dbo.FriendModels", "MyObservations_ID", "dbo.UserModels");
            DropForeignKey("dbo.FriendModels", "MyFollowers_ID", "dbo.UserModels");
            DropForeignKey("dbo.CommentModels", "Review_ID", "dbo.ReviewModels");
            DropForeignKey("dbo.ReviewModels", "BoardGame_ID", "dbo.BoardGameModels");
            DropForeignKey("dbo.ReviewModels", "Author_ID", "dbo.UserModels");
            DropForeignKey("dbo.CommentModels", "Author_ID", "dbo.UserModels");
            DropForeignKey("dbo.AdvertisementModels", "Author_ID", "dbo.UserModels");
            DropIndex("dbo.PlayerModels", new[] { "Player_ID" });
            DropIndex("dbo.PlayerModels", new[] { "Advertisement_ID" });
            DropIndex("dbo.MessageModels", new[] { "SenderUser_ID" });
            DropIndex("dbo.MessageModels", new[] { "ReceiverUser_ID" });
            DropIndex("dbo.FriendModels", new[] { "MyObservations_ID" });
            DropIndex("dbo.FriendModels", new[] { "MyFollowers_ID" });
            DropIndex("dbo.ReviewModels", new[] { "BoardGame_ID" });
            DropIndex("dbo.ReviewModels", new[] { "Author_ID" });
            DropIndex("dbo.CommentModels", new[] { "Review_ID" });
            DropIndex("dbo.CommentModels", new[] { "Author_ID" });
            DropIndex("dbo.AdvertisementModels", new[] { "BoardGame_ID" });
            DropIndex("dbo.AdvertisementModels", new[] { "Author_ID" });
            DropTable("dbo.PlayerModels");
            DropTable("dbo.MessageModels");
            DropTable("dbo.FriendModels");
            DropTable("dbo.BoardGameModels");
            DropTable("dbo.ReviewModels");
            DropTable("dbo.CommentModels");
            DropTable("dbo.UserModels");
            DropTable("dbo.AdvertisementModels");
        }
    }
}
