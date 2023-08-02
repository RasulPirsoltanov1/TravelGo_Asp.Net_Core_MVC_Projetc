using BusinessLayer.Abstract;
using BusinessLayer.Concrete.Main;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GuideManager : GenericService<Guide, IGuideDal>, IGuideService
    {
        public GuideManager(IGuideDal tdal) : base(tdal)
        {
        }
    }
}
