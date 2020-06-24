using System;
using System.Collections.Generic;

namespace server.Models
{
  public class User
  {
    public long ID { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
  }
}
