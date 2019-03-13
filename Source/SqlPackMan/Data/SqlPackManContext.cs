using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Models
{
    public class SqlPackManContext : DbContext
    {
        public SqlPackManContext(DbContextOptions<SqlPackManContext> options)
            : base(options)
        {
        }

        public DbSet<SqlPackMan.Models.PackageItem> PackageItem { get; set; }

        public DbSet<SqlPackMan.Models.Package> Package { get; set; }

        public DbSet<SqlPackMan.Models.DDSEnvironment> DDSEnvironment { get; set; }

        public DbSet<SqlPackMan.Models.Migration> Migration { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Migration>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (Lists.MigrationStatus)Enum.Parse(typeof(Lists.MigrationStatus), v));
            modelBuilder
                .Entity<Package>()
                .Property(e => e.Database)
                .HasConversion(
                    v => v.ToString(),
                    v => (Lists.Database)Enum.Parse(typeof(Lists.Database), v));

            modelBuilder
         .Entity<Package>()
         .Property(e => e.PackageStatus)
         .HasConversion(
             v => v.ToString(),
             v => (Lists.PackageStatus)Enum.Parse(typeof(Lists.PackageStatus), v));

            modelBuilder
              .Entity<PackageItem>()
              .Property(e => e.DbObjectType)
              .HasConversion(
                  v => v.ToString(),
                  v => (Lists.DbObjectType)Enum.Parse(typeof(Lists.DbObjectType), v));
        }
    }
}
