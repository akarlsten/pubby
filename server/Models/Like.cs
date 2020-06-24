namespace server.Models
{
  public class Like
  {
    public long ID { get; set; }
    public long OwnerID { get; set; }
    public long LikeTargetID { get; set; }
    public virtual User Owner { get; set; }
    public virtual Post LikeTarget { get; set; }
  }
}