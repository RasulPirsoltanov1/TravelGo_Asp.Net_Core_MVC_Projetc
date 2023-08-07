using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Contexts;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommenWithDestinations()
        {
            using(Context context=new Context())
            {
                return context.Set<Comment>().Include(c=>c.Destination).ToList();
            }
        }

        public List<Comment> GetCommenWithDestinationsAndUser(Expression<Func<Comment, bool>> expression)
        {
            using (Context context = new Context())
            {
                return context.Set<Comment>().Include(c => c.Destination).Include(c=>c.AppUser).Where(expression).ToList();
            }
        }
    }

}
