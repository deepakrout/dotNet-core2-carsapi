using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Model
{
    public class CarDBContext : DbContext
    {
        public CarDBContext(DbContextOptions<CarDBContext> options) : base (options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
