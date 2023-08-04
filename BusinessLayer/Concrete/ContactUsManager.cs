using BusinessLayer.Abstract;
using BusinessLayer.Concrete.Main;
using DataAccessLayer.Concrete.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactUsManager : GenericService<ContactUs, IContactUsDal>, IContactUsService
    {
        public ContactUsManager(IContactUsDal tdal) : base(tdal)
        {
        }
    }
}
