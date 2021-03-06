﻿// <auto-generated />
using System;
using HospitalDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalDAL.Migrations
{
    [DbContext(typeof(HospitalDB))]
    [Migration("20200825105151_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalDLL.Patient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("HospitalDLL.Problem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Patientid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Patientid");

                    b.ToTable("Problem");
                });

            modelBuilder.Entity("HospitalDLL.Treatment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dosage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Problemid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Problemid");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("HospitalDLL.Problem", b =>
                {
                    b.HasOne("HospitalDLL.Patient", null)
                        .WithMany("Problems")
                        .HasForeignKey("Patientid");
                });

            modelBuilder.Entity("HospitalDLL.Treatment", b =>
                {
                    b.HasOne("HospitalDLL.Problem", null)
                        .WithMany("Treatment")
                        .HasForeignKey("Problemid");
                });
#pragma warning restore 612, 618
        }
    }
}
