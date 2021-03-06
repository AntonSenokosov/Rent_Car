﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalCar { get; set; }
        public int CarPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get 
            {
                return (int)Math.Ceiling((decimal)(TotalCar / CarPerPage));
            }
        }
    }
}