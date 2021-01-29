using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Entities
{
    public class TypeBody
    {
        [Key]
        public int BodyId { get; set; }
        public string NameBody { get; set; }
        public List<Car> Cars { get; set; }
    }
}
