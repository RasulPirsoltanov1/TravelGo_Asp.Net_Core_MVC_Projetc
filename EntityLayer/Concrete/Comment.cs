using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Comment
    {

        [Key]
        public int CommentId { get; set; }
        public string CommentUser { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentState { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
    }
}
