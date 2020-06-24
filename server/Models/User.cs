using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
  public class User
  {
    public long ID { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
  }
}
