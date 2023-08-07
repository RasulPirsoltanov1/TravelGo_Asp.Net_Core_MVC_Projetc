using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Contexts;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Concrete.UnitOfWork;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAccountDal : GenericUnitOfWorkRepository<Account>, IAccountDal
    {
        public EfAccountDal(Context context, IUnitOfWorkDal unitOfWorkDal) : base(context, unitOfWorkDal)
        {
        }
    }

}
