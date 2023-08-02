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
        IReservationDal _tdal;
        public ReservationManager(IReservationDal tdal) : base(tdal)
        {
            _tdal = tdal;
        }
        public List<Reservation> GetAllReservationsWithDestination(Expression<Func<Reservation, bool>> expression)
        {
            return _tdal.GetAllReservationsWithDestination(expression);
        }
    }
}
