using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CityRealEstate.Models;

namespace CityRealEstate.Data
{
    public class CityRealEstateContext : DbContext
    {
        public CityRealEstateContext (DbContextOptions<CityRealEstateContext> options)
            : base(options)
        {
        }

        public DbSet<CityRealEstate.Models.Property> Property { get; set; }

        public DbSet<CityRealEstate.Models.BuyProperty> BuyProperty { get; set; }

        public DbSet<CityRealEstate.Models.ReachUs> ReachUs { get; set; }
    }
}
