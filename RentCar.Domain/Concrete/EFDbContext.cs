using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        //public EFDbContext():base()
        //{ }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<TypeBody> TypeBodies { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
