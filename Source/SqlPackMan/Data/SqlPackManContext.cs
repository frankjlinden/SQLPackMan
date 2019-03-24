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

        public DbSet<SqlPackMan.Models.DdsEnvironment> DdsEnvironment { get; set; }

        public DbSet<SqlPackMan.Models.Migration> Migration { get; set; }
               
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<DdsEnvironment>()
            .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder
                .Entity<Package>()
                .Property(e => e.DdsEnvironmentId)
                .HasDefaultValue(0);

            modelBuilder
                .Entity<Package>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder
              .Entity<PackageItem>()
              .Property<string>("Tags")
             .HasField("_tags");



            //modelBuilder
            //    .Entity<Package>()
            //    .Property(e => e.Status)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (Lists.Status)Enum.Parse(typeof(Lists.Status), v));

            //modelBuilder
            //  .Entity<PackageItem>()
            //  .Property(e => e.DbObjectType)
            //  .HasConversion(
            //      v => v.ToString(),
            //      v => (Lists.DbObjectType)Enum.Parse(typeof(Lists.DbObjectType), v));
            //modelBuilder
            //.Entity<PackageItem>()
            //.Property(e => e.Status)
            //.HasConversion(
            //    v => v.ToString(),
            //    v => (Lists.Status)Enum.Parse(typeof(Lists.Status), v));

        }
    }
}
