using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.GetCommentsWithDestination();
            return View(values);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _commentService.TDelete(_commentService.TGetById(Id));
            return RedirectToAction("Index");   
        }
    }
}
