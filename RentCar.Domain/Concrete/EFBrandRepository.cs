﻿using RentCar.Domain.Abstract;
using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Concrete
{
    public class EFBrandRepository : IBrandRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Brand> AllBrand
        {
            get
            {
                return context.Brands;
            }
        }
    }
}
