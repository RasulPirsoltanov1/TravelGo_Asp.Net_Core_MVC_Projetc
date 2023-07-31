using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> GetAllReservationsWithDestination(Expression<Func<Reservation,bool>> expression);
    }
}
