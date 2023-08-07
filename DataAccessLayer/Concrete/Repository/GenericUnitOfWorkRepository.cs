using DataAccessLayer.Concrete.Abstract.Generics;
using DataAccessLayer.Concrete.Contexts;
using DataAccessLayer.Concrete.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericUnitOfWorkRepository<T> : IGenericUnitOfWorkDal<T> where T : class
    {

        private readonly Context _context;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public GenericUnitOfWorkRepository(Context context, IUnitOfWorkDal unitOfWorkDal)
        {
            _context = context;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _unitOfWorkDal.save();
        }

        public void MultiUpdate(List<T> values)
        {
            _context.Set<T>().UpdateRange(values);
            _unitOfWorkDal.save();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _unitOfWorkDal.save();
        }
    }
}
