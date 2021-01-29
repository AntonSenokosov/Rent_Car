﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string NameBrand { get; set; }
        public string NameModel { get; set; }
        public List<Car> Cars { get; set; }
    }
}
