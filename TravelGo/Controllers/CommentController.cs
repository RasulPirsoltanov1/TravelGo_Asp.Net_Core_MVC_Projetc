using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelGo.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private ICommentService _commentManager;
        private UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentManager, UserManager<AppUser> userManager)
        {
            _commentManager = commentManager;
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(EntityLayer.Concrete.Comment comment)
        {
            AppUser appUser = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (appUser != null)
            {
                comment.AppUserId = appUser.Id;
            }
            comment.CommentDate = DateTime.UtcNow;
            comment.CommentState = true;
            _commentManager.TAdd(comment);
            return RedirectToAction("DestinationDetails", "Destination", new { id = comment.DestinationId });
        }

    }
}
