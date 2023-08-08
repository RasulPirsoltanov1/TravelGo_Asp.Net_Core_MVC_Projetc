using DataAccessLayer.Concrete.Abstract.Generics;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
        Destination GetDestinationWithGuide(Expression<Func<Destination,bool>> expression);
    }
}
