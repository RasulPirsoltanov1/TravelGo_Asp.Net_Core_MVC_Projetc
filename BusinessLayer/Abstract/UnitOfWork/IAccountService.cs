using EntityLayer.Concrete;

namespace BusinessLayer.Abstract.UnitOfWork
{
    public interface IAccountService : IGenericUnitOfWorkService<Account>
    {
    }
}
