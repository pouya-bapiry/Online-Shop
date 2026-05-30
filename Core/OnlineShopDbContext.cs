using Core.Entities;
using Core.FluentApiConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class OnlineShopDbContext:DbContext
    {
        public OnlineShopDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

        }
    }
}
