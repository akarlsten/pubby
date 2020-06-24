
namespace server.Models
{
  public class Upvote
  {
    public long ID { get; set; }
    public long OwnerID { get; set; }
    public long LikeTargetID { get; set; }
    public virtual User Owner { get; set; }
    public virtual Comment LikeTarget { get; set; }
  }
}