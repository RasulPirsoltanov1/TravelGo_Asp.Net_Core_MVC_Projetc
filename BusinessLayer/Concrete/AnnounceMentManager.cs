using BusinessLayer.Abstract;
using BusinessLayer.Concrete.Main;
using DataAccessLayer.Concrete.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : GenericService<Announcement, IAnnouncementDal>,IAnnouncementService
    {
        public AnnouncementManager(IAnnouncementDal tdal) : base(tdal)
        {
        }
    }
}
