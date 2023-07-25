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
    public class DestinationManager : Manager<Destination, EfDestinationDal>, IDestinationService
    {
        public DestinationManager(EfDestinationDal dal) : base(dal)
        {

        }
    }
}
