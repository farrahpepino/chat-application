using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Data{
    public class AppDbContext: DbContext{
        public DbSet<User> Users {get; set;}
        public DbSet<ChatRoom> ChatRooms {get; set;}
        public DbSet<Message> Messages {get; set;}


        public AppDbContext (DbContextOptions<AppDbContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
        }
    }
}