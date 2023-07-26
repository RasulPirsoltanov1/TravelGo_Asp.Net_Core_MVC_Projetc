using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Controllers
{
    public class CommentController : Controller
    {
        private CommentManager _commentManager = new CommentManager(new EfCommentDal());
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(EntityLayer.Concrete.Comment comment)
        {
            comment.CommentDate = DateTime.UtcNow;
            comment.CommentState = true;
            _commentManager.TAdd(comment);
            return RedirectToAction("DestinationDetails", "Destination", new { id = comment.DestinationId });
        }
    }
}
