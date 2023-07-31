using DataAccessLayer.Concrete.Abstract.Generics;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetAllReservationsWithDestination(Expression<Func<Reservation, bool>> predicate);
    }
}
