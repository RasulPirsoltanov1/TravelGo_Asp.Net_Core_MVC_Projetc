using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : Manager<Reservation, EfReservationDal>, IReservationService
    {
        public ReservationManager(EfReservationDal dal) : base(dal)
        {
        }

        public List<Reservation> GetAllReservationsWithDestination(Expression<Func<Reservation, bool>> expression)
        {
            EfReservationDal dal = new EfReservationDal();
            return dal.GetAllReservationsWithDestination(expression);
        }
    }
}
