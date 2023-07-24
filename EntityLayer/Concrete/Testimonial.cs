using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int TestimonialId { get; set; }
        public string Client { get; set; }
        public string Message { get; set; }
        public string ClientImage { get; set; }
        public bool Status { get; set; }
    }
}
