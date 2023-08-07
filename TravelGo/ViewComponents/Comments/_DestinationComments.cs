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
            var comments = _commentManager.GetCommentsWithDestinationAndAppUser(c => c.DestinationId == id);
            ViewBag.Count = _commentManager.TGetListByFilter(c => c.DestinationId == id).Count;
            foreach (var item in comments)
            {
                if (item.AppUser == null)
                {
                    item.AppUser = new AppUser()
                    {
                        Name = "Anonim",
                        ImageUrl= "https://img.freepik.com/free-icon/user_318-826358.jpg"
                    };
                }
            }
            return View(comments);
        }
    }
}
