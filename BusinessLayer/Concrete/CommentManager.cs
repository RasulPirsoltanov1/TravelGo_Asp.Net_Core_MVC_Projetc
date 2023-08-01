using BusinessLayer.Abstract;
using BusinessLayer.Concrete.Main;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Abstract.Generics;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class CommentManager : GenericService<Comment,ICommentDal>, ICommentService
    {
        private ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal) : base(commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> GetCommentsWithDestination()
        {
            return _commentDal.GetCommenWithDestinations();
        }
    }
}
