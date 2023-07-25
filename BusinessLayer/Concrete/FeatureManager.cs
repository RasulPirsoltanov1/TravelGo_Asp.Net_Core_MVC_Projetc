using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : Manager<Feature, EfFeatureDal>, IFeatureService
    {
        public FeatureManager(EfFeatureDal dal) : base(dal)
        {
        }
    }
}
