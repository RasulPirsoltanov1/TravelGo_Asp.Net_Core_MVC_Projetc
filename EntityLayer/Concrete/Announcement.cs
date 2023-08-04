using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Contante { get; set; }
        public DateTime? Date { get; set; }
    }
}
