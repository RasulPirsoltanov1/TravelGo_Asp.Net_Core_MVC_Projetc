using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Abstract.Generics;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);

        }

        public About TGetById(int Id)
        {
            return _aboutDal.GetList().FirstOrDefault(a => a.AboutId == Id) == null ? null : _aboutDal.GetList().FirstOrDefault(a => a.AboutId == Id);
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
