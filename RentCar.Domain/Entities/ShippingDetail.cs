using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Entities
{
    public class ShippingDetail
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Укажите ФИО")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите ваш номер телефона")]
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Укажите город получения")]
        public string CitySupply { get; set; }
        [Required(ErrorMessage = "Укажите место получения")]
        public string PlaceSupply { get; set; }
        [Required(ErrorMessage = "Укажите город возврата")]
        public string CityReturn { get; set; }
        [Required(ErrorMessage = "Укажите место возврата")]
        public string PlaceReturn { get; set; }
        //[Required(ErrorMessage = "Укажите время получения авто")]
        //[DataType(DataType.DateTime)]
        //public DateTime DateSupply { get; set; }
        //[Required(ErrorMessage = "Укажите время возврата авто")]
        //[DataType(DataType.DateTime)]
        //public DateTime DateReturn { get; set; }
    }
}
