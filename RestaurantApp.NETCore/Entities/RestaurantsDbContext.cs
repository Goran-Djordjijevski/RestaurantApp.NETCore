using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.NETCore.Entities
{
    public class RestaurantsDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
