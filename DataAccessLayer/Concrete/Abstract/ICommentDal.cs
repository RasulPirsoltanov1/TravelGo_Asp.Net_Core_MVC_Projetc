using DataAccessLayer.Concrete.Abstract.Generics;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetCommenWithDestinations();
        List<Comment> GetCommenWithDestinationsAndUser(Expression<Func<Comment, bool>> expression);
    }
}
