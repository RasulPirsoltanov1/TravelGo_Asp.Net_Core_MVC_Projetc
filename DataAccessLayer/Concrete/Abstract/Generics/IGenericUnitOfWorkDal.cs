using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Abstract.Generics
{
    public interface IGenericUnitOfWorkDal<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        T GetById(int id);
        void MultiUpdate(List<T> values);
    }
}
