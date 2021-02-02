using RentCar.Domain.Abstract;
using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Concrete
{
    public class EFOrderRepository:IOrderRepository
    {
        EFDbContext db = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get
            {
                return db.Orders;
            }
        }
    }
}
