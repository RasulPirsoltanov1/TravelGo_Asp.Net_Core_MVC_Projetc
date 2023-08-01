using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal dal;

        public CommentManager(ICommentDal dal)
        {
            this.dal = dal;
        }

        public List<Comment> GetCommentsWithDestination()
        {
            return dal.GetCommenWithDestinations();
        }

        public void TAdd(Comment t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Comment t)
        {
            dal.Delete(t);
        }

        public Comment TGetById(int Id)
        {
            return dal.GetById(Id);    
        }

        public List<Comment> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
