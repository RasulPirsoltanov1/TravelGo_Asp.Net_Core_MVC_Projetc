using BusinessLayer.Abstract;
using BusinessLayer.Concrete.Main;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : GenericService<Reservation, IReservationDal>, IReservationService
    {
        IReservationDal tdal;
        public ReservationManager(IReservationDal tdal) : base(tdal)
        {
        }
        public List<Reservation> GetAllReservationsWithDestination(Expression<Func<Reservation, bool>> expression)
        {
            return tdal.GetAllReservationsWithDestination(expression);
        }
    }
}
