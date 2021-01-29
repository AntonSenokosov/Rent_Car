using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Entities
{
    public class Transmission
    {
        public int TransmissionId { get; set; }
        public string NameTransmission { get; set; }
        public List<Car> Cars { get; set; }
    }
}
