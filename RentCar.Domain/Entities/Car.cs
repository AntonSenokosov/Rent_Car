using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Entities
{
    public class Car
    {
        [Key]
        public string NumberCar { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual TypeBody TypeBody { get; set; }
        public int volumeEndine { get; set; }
        public virtual Fuel Fuel { get; set; }
        public int year { get; set; }
        public int countDoor { get; set; }
        public decimal price { get; set; }
        public decimal costOfDay { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string shortDesc { set; get; }
        public string longDesc { set; get; }
        public bool isFavorite { set; get; }
        public bool available { set; get; }
        public List<Order> Orders { get; set; }
    }
}
