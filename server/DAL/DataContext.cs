using server.Models;
using Microsoft.EntityFrameworkCore;

namespace server.Models
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Upvote> Upvotes { get; set; }
    public DbSet<Like> Likes { get; set; }

  }
}