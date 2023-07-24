using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class SubAbout
    {
        [Key]
        public int SubAbout2Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
