using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> GetCommentsWithDestination();    
        List<Comment> GetCommentsWithDestinationAndAppUser(Expression<Func<Comment,bool>> expression);
    }
}
