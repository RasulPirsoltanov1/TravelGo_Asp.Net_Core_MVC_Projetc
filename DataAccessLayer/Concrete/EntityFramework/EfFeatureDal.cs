﻿using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
    {

    }
   
}
