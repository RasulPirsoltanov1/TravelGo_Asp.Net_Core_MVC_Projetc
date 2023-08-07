using DataAccessLayer.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.UnitOfWork
{
    public class UnitOfWorkDal:IUnitOfWorkDal
    {
        private Context _context;

        public UnitOfWorkDal(Context context)
        {
            _context = context;
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
