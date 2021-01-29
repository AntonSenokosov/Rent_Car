using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Entities
{
    public class Fuel
    {
        public int FuelId { get; set; }
        public string NameFuel { get; set; }
        public List<Car> Cars { get; set; }
    }
}
