using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Contexts;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfSubAboutDal : GenericRepository<SubAbout>, ISubAboutDal
    {

    }
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetAllReservationsWithDestination(Expression<Func<Reservation, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Set<Reservation>().Where(predicate).ToList();
            }
        }
    }

}
