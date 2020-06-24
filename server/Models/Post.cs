using System;
using System.Collections.Generic;

namespace server.Models
{
  public class Post
  {
    public long ID { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Likes { get; set; }
    public long AuthorID { get; set; }
    public virtual User Author { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
  }
}