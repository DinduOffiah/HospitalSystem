﻿using Microsoft.EntityFrameworkCore;
using RegisterService.Models;
using System.Collections.Generic;

namespace AppDbContext.Data
{
    public class VitalDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public VitalDbContext(DbContextOptions<VitalDbContext> options)
          : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        //For correctly mapping "Decimal" data type to the corresponding column in the database.
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Bid>().Property(b => b.Amount).HasPrecision(10, 2);
        //    base.OnModelCreating(modelBuilder);

        //    // This tells Entity Framework to use the User table instead of AspNetUsers for the User entity.
        //    modelBuilder.Entity<User>().ToTable("User");
        //}

    }
}
