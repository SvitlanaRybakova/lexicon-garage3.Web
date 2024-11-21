﻿using lexicon_garage3.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace lexicon_garage3.Persistance.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().HasKey(t => t.RegNumber);


            // generated by chatGPT
            // The Principal Side: Vehicle is the principal.The Dependent Side: ParkingSpot is the dependent and holds the foreign key(RegNumber)
            modelBuilder.Entity<ParkingSpot>()
             .HasOne(p => p.Vehicle) 
             .WithOne(v => v.ParkingSpot)
             .HasForeignKey<ParkingSpot>(p => p.RegNumber)
             .IsRequired(false); // Make the foreign key optional

            //vehicletype stores the enum name ("Small", "Medium", "Large") as a string
            modelBuilder.Entity<VehicleType>()
           .Property(v => v.VehicleSize)
           .HasConversion<string>(); 

        }
        public DbSet<lexicon_garage3.Core.Entities.Member> Member { get; set; } = default!;
        public DbSet<lexicon_garage3.Core.Entities.ParkingSpot> ParkingSpot { get; set; } = default!;
        public DbSet<lexicon_garage3.Core.Entities.Vehicle> Vehicle { get; set; } = default!;
        public DbSet<lexicon_garage3.Core.Entities.VehicleType> VehicleType { get; set; } = default!;
    }
}
