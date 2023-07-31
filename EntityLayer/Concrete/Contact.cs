using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Contact
    {

        [Key]
        public int ContactId { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string MapLocation { get; set; }
        public bool Status { get; set; }
    }
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
