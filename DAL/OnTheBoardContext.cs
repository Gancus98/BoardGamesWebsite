using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BoardGame.Models;

namespace BoardGame.DAL
{
    public class OnTheBoardContext : DbContext
    {
        public OnTheBoardContext ():base("OnTheBoardDatabase")
        {
            Database.SetInitializer(new OnTheBoardDBInitializer<OnTheBoardContext>());
        }
        public DbSet<UserModels> User { get; set; }
        public DbSet<ReviewModels> Review { get; set; }
        public DbSet<PlayerModels> Player { get; set; }
        public DbSet<MessageModels> Message { get; set; }
        public DbSet<FriendModels> Friend { get; set; }
        public DbSet<CommentModels> Comment { get; set; }
        public DbSet<BoardGameModels> BoardGame { get; set; }
        public DbSet<AdvertisementModels> Advertisement { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageModels>() 
                .HasRequired(m => m.SenderUser)
                .WithMany(t => t.MessagesSent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MessageModels>()
                .HasRequired(m => m.ReceiverUser)
                .WithMany(t => t.MessagesReceive)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FriendModels>()
                .HasRequired(m => m.MyObservations)
                .WithMany(t => t.Observations)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FriendModels>()
                .HasRequired(m => m.MyFollowers)
                .WithMany(t => t.Followers)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}