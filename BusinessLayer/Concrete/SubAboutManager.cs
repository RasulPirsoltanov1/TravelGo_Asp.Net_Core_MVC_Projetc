using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : Manager<SubAbout, EfSubAboutDal>, ISubAboutService
    {
        public SubAboutManager(EfSubAboutDal dal) : base(dal)
        {
        }
    }
}
