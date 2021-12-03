using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeTask.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTask
{
    public class MyDbContext :DbContext
    {
        public MyDbContext() : base() {  }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source = Cities.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CityConfigurator().Configure(modelBuilder.Entity<City>());
            new CountryConfigurator().Configure(modelBuilder.Entity<Country>());
        }


        private class CityConfigurator : IEntityTypeConfiguration<City>
        {
            public void Configure(EntityTypeBuilder<City> builder)
            {
                builder.Navigation(c => c.Country).AutoInclude();
                builder.HasOne(c => c.Country).WithMany(c => c.Cities);
            }
        }

        private class CountryConfigurator : IEntityTypeConfiguration<Country>
        {
            public void Configure(EntityTypeBuilder<Country> builder)
            {
                builder.Navigation(c => c.Cities).AutoInclude();
                builder.HasMany(c => c.Cities).WithOne(c => c.Country);
            }
        }

    }
}
