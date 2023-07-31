using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommentManager : Manager<Comment, EfCommentDal>
    {
        public CommentManager(EfCommentDal dal) : base(dal)
        {
        }
    }
}
