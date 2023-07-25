using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Default
{
    public class _SubAbouts : ViewComponent
    {
        SubAboutManager _subAboutManager=new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            SubAbout value = _subAboutManager.TGetList().Where(sb=>sb.SubAboutId==1).First();
            return View(value);
        }
    }
}
