using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Abstract.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Manager<T,TDal> : IGenericService<T> where T : class where TDal:IGenericDal<T>
    {
        private TDal _dal;

        public Manager(TDal dal)
        {
            this._dal = dal;
        }

        public void TAdd(T t)
        {
            _dal.Insert(t);
        }

        public void TDelete(T t)
        {
            _dal.Delete(t);
        }

        public T TGetById(int Id)
        {
            return _dal.GetById(Id);
        }

        public List<T> TGetList()
        {
            return _dal.GetList();
        }

        public List<T> TGetListByFilter(Expression<Func<T, bool>> expression)
        {
            return _dal.TGetListByFilter(expression);
        }

        public void TUpdate(T t)
        {
            _dal.Update(t);
        }
    }
}
