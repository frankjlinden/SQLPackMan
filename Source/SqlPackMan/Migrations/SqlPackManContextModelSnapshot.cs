﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SqlPackMan.Models;

namespace SqlPackMan.Migrations
{
    [DbContext(typeof(SqlPackManContext))]
    partial class SqlPackManContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SqlPackMan.Models.DbObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DbObjectTypeId");

                    b.Property<string>("ObjectName")
                        .HasMaxLength(150);

                    b.Property<int>("PackageId");

                    b.Property<int>("StatusId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("DbObjectTypeId");

                    b.HasIndex("PackageId");

                    b.HasIndex("StatusId");

                    b.ToTable("DbObject");
                });

            modelBuilder.Entity("SqlPackMan.Models.DbObjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RGType")
                        .HasMaxLength(50);

                    b.Property<string>("SqlType")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DbObjType");
                });

            modelBuilder.Entity("SqlPackMan.Models.DdsEnvironment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("SchemaPath")
                        .HasMaxLength(150);

                    b.Property<string>("Server")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("DdsEnvironment");
                });

            modelBuilder.Entity("SqlPackMan.Models.Migration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DdsEnvironmentId");

                    b.Property<string>("Name");

                    b.Property<int>("PackageId");

                    b.Property<string>("PackageScript");

                    b.Property<string>("PostScript");

                    b.Property<string>("PreScript");

                    b.Property<string>("Status")
                        .HasMaxLength(50);

                    b.Property<int>("TargetEnvironment");

                    b.HasKey("Id");

                    b.HasIndex("DdsEnvironmentId");

                    b.HasIndex("PackageId");

                    b.ToTable("Migration");
                });

            modelBuilder.Entity("SqlPackMan.Models.MigrationResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MigrationId");

                    b.Property<string>("ResultText");

                    b.Property<string>("Step")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("MigrationId");

                    b.ToTable("MigrationResult");
                });

            modelBuilder.Entity("SqlPackMan.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurEnvironmentId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("DbName")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<int>("MaxEnvironmentId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("StatusDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<int>("Version")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("CurEnvironmentId");

                    b.HasIndex("MaxEnvironmentId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("StatusId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("SqlPackMan.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsItemLevel");

                    b.Property<string>("Label")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("SqlPackMan.Models.DbObject", b =>
                {
                    b.HasOne("SqlPackMan.Models.DbObjectType", "DbObjectType")
                        .WithMany()
                        .HasForeignKey("DbObjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SqlPackMan.Models.Package", "Package")
                        .WithMany("Items")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SqlPackMan.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SqlPackMan.Models.Migration", b =>
                {
                    b.HasOne("SqlPackMan.Models.DdsEnvironment", "Environment")
                        .WithMany()
                        .HasForeignKey("DdsEnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SqlPackMan.Models.Package", "Package")
                        .WithMany("Migrations")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SqlPackMan.Models.MigrationResult", b =>
                {
                    b.HasOne("SqlPackMan.Models.Migration", "Migration")
                        .WithMany("MigrationResults")
                        .HasForeignKey("MigrationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SqlPackMan.Models.Package", b =>
                {
                    b.HasOne("SqlPackMan.Models.DdsEnvironment", "CurEnvironment")
                        .WithMany()
                        .HasForeignKey("CurEnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SqlPackMan.Models.DdsEnvironment", "MaxEnvironment")
                        .WithMany()
                        .HasForeignKey("MaxEnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SqlPackMan.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
