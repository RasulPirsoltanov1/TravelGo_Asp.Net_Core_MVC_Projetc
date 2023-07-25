using DataAccessLayer.Concrete.Abstract.Generics;
using DataAccessLayer.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using (var context = new Context())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public T GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Set<T>().Find(id);
            }
        }


        public List<T> GetList()
        {
            using (var context = new Context())
            {
                return context.Set<T>().ToList();
                context.SaveChanges();
            }
        }

        public void Insert(T entity)
        {
            using (var context = new Context())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var context = new Context())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
