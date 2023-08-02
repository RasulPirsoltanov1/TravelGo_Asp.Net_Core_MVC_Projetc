using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Contexts;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetAllReservationsWithDestination(Expression<Func<Reservation, bool>> predicate)
        {
            using (var context = new Context())
            {
                return context.Set<Reservation>().Include(r => r.Destination).Where(predicate).ToList();
            }
        }
    }

}
