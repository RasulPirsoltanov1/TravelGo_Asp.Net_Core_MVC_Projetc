using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Abstract.Generics;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.Main
{
    public class GenericService<T, Tdal> : IGenericService<T> where Tdal : IGenericDal<T>
    {
        Tdal _tdal;

        public GenericService(Tdal tdal)
        {
            this._tdal = tdal;
        }

        public void TAdd(T t)
        {
           _tdal.Insert(t);
        }

        public void TDelete(T t)
        {
            _tdal.Delete(t);
        }

        public T TGetById(int Id)
        {
           return _tdal.GetById(Id);
        }

        public List<T> TGetList()
        {
            return _tdal.GetList();
        }

        public List<T> TGetListByFilter(Expression<Func<T, bool>> expression)
        {
            return _tdal.TGetListByFilter(expression);
        }

        public void TUpdate(T t)
        {
            _tdal.Update(t);
        }
    }
}
