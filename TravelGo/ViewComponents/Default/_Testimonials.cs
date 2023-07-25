using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Default
{
    public class _Testimonials:ViewComponent
    {
        TestimonialManager _testimonialManager = new TestimonialManager(new DataAccessLayer.Concrete.EntityFramework.EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            List<Testimonial> testimonials = _testimonialManager.TGetList();
            return View(testimonials);
        }
    }
}
