using BusinessLayer.Abstract.UnitOfWork;
using BusinessLayer.Concrete.Main;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete.UnitOfWork
{
    public class AccountManager : UOWManager<Account, IAccountDal>, IAccountService
    {
        public AccountManager(IAccountDal dal) : base(dal)
        {
        }
    }
}
