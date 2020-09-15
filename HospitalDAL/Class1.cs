using HospitalDLL;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalDAL
{
    public class HospitalDB : DbContext
    {
        public HospitalDB(DbContextOptions<HospitalDB> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Problem>().ToTable("Problem");
            modelBuilder.Entity<Treatment>().ToTable("Treatment");
        }

        public DbSet<Patient> patients { get; set; }
    }
}
