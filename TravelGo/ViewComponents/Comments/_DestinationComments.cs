using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Comment
{
    public class _DestinationComments : ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var comments = _commentManager.TGetListByFilter(c => c.DestinationId == id);
            ViewBag.Count= _commentManager.TGetListByFilter(c => c.DestinationId == id).Count;
            return View(comments);
        }
    }
}
