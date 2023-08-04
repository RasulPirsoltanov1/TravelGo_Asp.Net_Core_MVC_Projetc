using BusinessLayer.Abstract;
using BusinessLayer.Concrete.Main;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Abstract.Generics;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : GenericService<AppUser, IAppUserDal>, IAppUserService
    {
        public AppUserManager(IAppUserDal tdal) : base(tdal)
        {
        }
    }
}
