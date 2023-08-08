using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Contexts;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(Expression<Func<Destination,bool>> expression)
        {
            using(var _context=new Context())
            {
                return _context.Set<Destination>().Include(d=>d.Guide).Where(expression).First();
            }
        }
    }

}
