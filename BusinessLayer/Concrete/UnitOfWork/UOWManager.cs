using BusinessLayer.Abstract.UnitOfWork;
using DataAccessLayer.Concrete.Abstract.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.UnitOfWork
{
    public class UOWManager<T, TDal> : IGenericUnitOfWorkService<T> where T : class where TDal : IGenericUnitOfWorkDal<T>
    {
        TDal _dal;
        public UOWManager(TDal dal)
        {
            _dal = dal;
        }

        public T TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public void TInsert(T entity)
        {
            _dal.Insert(entity);
        }

        public void TMultiUpdate(List<T> entity)
        {
            _dal.MultiUpdate(entity);
        }

        public void TUpdate(T entity)
        {
            _dal.Update(entity);
        }
    }
}
