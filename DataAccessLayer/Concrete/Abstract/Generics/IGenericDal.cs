using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Abstract.Generics
{
    public interface IGenericDal<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetList();
        T GetById(int id);
    }
}
