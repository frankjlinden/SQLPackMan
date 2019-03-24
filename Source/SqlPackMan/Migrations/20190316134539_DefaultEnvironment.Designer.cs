﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SqlPackMan.Models;

namespace SqlPackMan.Migrations
{
    [DbContext(typeof(SqlPackManContext))]
    [Migration("20190316134539_DefaultEnvironment")]
    partial class DefaultEnvironment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SqlPackMan.Models.DdsEnvironment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Server");

                    b.Property<string>("SourceEnv")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("TargetEnv")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("ID");

                    b.ToTable("DdsEnvironment");
                });

            modelBuilder.Entity("SqlPackMan.Models.Migration", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Database");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Name");

                    b.Property<string>("ResultText");

                    b.Property<int?>("SourceEnvironmentID");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("ID");

                    b.HasIndex("SourceEnvironmentID");

                    b.ToTable("Migration");
                });

            modelBuilder.Entity("SqlPackMan.Models.Package", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DdsEnvironmentId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("Database")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Description");

                    b.Property<int>("MaxEnvironment");

                    b.Property<string>("Name");

                    b.Property<string>("ScriptItems");

                    b.Property<string>("ScriptPost");

                    b.Property<string>("ScriptPre");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<DateTime>("StatusDate");

                    b.Property<int>("StepNumber");

                    b.Property<string>("Version");

                    b.HasKey("ID");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("SqlPackMan.Models.PackageItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DbObjectName");

                    b.Property<string>("DbObjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<int>("PackageId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<int>("StepNumber");

                    b.HasKey("ID");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageItem");
                });

            modelBuilder.Entity("SqlPackMan.Models.Migration", b =>
                {
                    b.HasOne("SqlPackMan.Models.DdsEnvironment", "SourceEnvironment")
                        .WithMany()
                        .HasForeignKey("SourceEnvironmentID");
                });

            modelBuilder.Entity("SqlPackMan.Models.PackageItem", b =>
                {
                    b.HasOne("SqlPackMan.Models.Package")
                        .WithMany("Items")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
