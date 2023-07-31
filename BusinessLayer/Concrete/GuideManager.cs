using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GuideManager : Manager<Guide, EfGuideDal>, IGuideService
    {
        public GuideManager(EfGuideDal dal) : base(dal)
        {
        }
    }
}
