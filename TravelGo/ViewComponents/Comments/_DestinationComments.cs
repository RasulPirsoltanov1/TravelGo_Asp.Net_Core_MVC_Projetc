using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.ViewComponents.Comment
{
    public class _DestinationComments : ViewComponent
    {
        ICommentService _commentManager;

        public _DestinationComments(ICommentService commentManager)
        {
            _commentManager = commentManager;
        }

        public IViewComponentResult Invoke(int id)
        {
            var comments = _commentManager.TGetListByFilter(c => c.DestinationId == id);
            ViewBag.Count= _commentManager.TGetListByFilter(c => c.DestinationId == id).Count;
            return View(comments);
        }
    }
}
