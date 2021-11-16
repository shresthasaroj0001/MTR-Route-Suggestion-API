using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3_Core.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            ) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<StationLink> StationLinks { get; set; }
        public DbSet<RouteSearch> RouteSearches { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>().HasData(
                new Station {
                Id =1,
                Name="Zero",
                Description="Zero"
            },
                new Station
                {
                    Id = 2,
                    Name = "One",
                    Description = "One"
                },
                new Station
                {
                    Id = 3,
                    Name = "Two",
                    Description = "Two"
                },
                new Station
                {
                    Id = 4,
                    Name = "Three",
                    Description = "Three"
                },
                new Station
                {
                    Id = 5,
                    Name = "Four",
                    Description = "Four"
                },
                new Station
                {
                    Id = 6,
                    Name = "Five",
                    Description = "Five"
                },
                new Station
                {
                    Id = 7,
                    Name = "Six",
                    Description = "Six"
                },
                new Station
                {
                    Id = 8,
                    Name = "Seven",
                    Description = "Seven"
                },
                new Station
                {
                    Id = 9,
                    Name = "Eight",
                    Description = "Eight"
                });
        }
    }
}
