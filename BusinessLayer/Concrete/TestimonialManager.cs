using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : Manager<Testimonial, EfTestimonialDal>
    {
        public TestimonialManager(EfTestimonialDal dal) : base(dal)
        {
        }
    }
}
