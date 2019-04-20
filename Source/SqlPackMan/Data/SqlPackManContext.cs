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

        public DbSet<SqlPackMan.Models.DbObject> DbObject { get; set; }
        public DbSet<DbObjectType> DbObjType { get; set; }
        public DbSet<SqlPackMan.Models.Package> Package { get; set; }
        public DbSet<SqlPackMan.Models.DdsEnvironment> DdsEnvironment { get; set; }
        public DbSet<SqlPackMan.Models.Migration> Migration { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<DdsEnvironment>()
            .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder
                .Entity<Package>()
                .Property(e => e.CurEnvironmentId)
                .HasDefaultValue(1);

            modelBuilder
                .Entity<Package>()
                .Property(e => e.MaxEnvironmentId)
                .HasDefaultValue(1);

            //modelBuilder.Entity<Package>()
            //    .HasOne(p => p.MaxEnvironment).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Package>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder
                 .Entity<Package>()
                 .Property(p => p.StatusId)
                 .HasDefaultValue(1);

            modelBuilder
            .Entity<Package>()
            .Property(p => p.StatusDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder
           .Entity<Package>()
           .Property(p => p.Version)
           .HasDefaultValue(1);

            modelBuilder
            .Entity<DbObject>()
            .Property(d => d.Version)
            .HasDefaultValue(1);

            modelBuilder
            .Entity<DbObject>()
            .Property(d => d.StatusId)
            .HasDefaultValue(1);
        }
    }
}
