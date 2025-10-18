using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ChatRoom> Chatrooms { get; set; }
        public DbSet<Message> Messages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<ChatRoom>().ToTable("chatrooms");
            modelBuilder.Entity<ChatRoom>()
            .Property(c => c.Participants)
            .HasConversion(
                v => string.Join(",", v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
            modelBuilder.Entity<Message>().ToTable("messages");

        }
    }
}