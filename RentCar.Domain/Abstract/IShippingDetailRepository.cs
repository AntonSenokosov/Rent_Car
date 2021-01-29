using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Abstract
{
    public interface IShippingDetailRepository
    {
        IEnumerable<ShippingDetail> ShippingDetails { get; }
    }
}
