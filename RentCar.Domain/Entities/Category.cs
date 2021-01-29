﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string NameCategory { get; set; }
        public List<Car> Cars { get; set; }
    }
}
