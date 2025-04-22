using Microsoft.EntityFrameworkCore;

namespace Practice1.Services.EntityFramework.Entities
{
    internal class PracticeContext: DbContext
    {
        public PracticeContext(DbContextOptions options)
            : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<Friendship> Friendships { get; set; }

        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure friendships
            // User has friends in other users
            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.User)
                .WithMany(u => u.Friends)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Friend)
                .WithMany(u => u.FriendOf)
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure likes
            // Posts are liked by users, users have liked posts
            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
