using RentCar.Domain.Abstract;
using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Domain.Concrete
{
    public class EFTypeBodyRepository : ITypeBodyRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<TypeBody> TypeBodies
        {
            get
            {
                return context.TypeBodies;
            }
        }
    }
}
