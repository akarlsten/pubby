using System;
using System.Collections.Generic;

namespace server.Models
{
  public class Comment
  {
    public long ID { get; set; }
    public string Content { get; set; }
    public long AuthorID { get; set; }
    public long PostID { get; set; }
    public virtual User Author { get; set; }
    public virtual Post Post { get; set; }
  }
}