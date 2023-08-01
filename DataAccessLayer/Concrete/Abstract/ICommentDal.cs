using DataAccessLayer.Concrete.Abstract.Generics;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetCommenWithDestinations();

    }
}
