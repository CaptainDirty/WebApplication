﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.Data;

namespace WebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210527053449_Upd")]
    partial class Upd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("WebApplication.Models.ClassInputModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("C2H6")
                        .HasColumnType("REAL");

                    b.Property<double>("C3H8")
                        .HasColumnType("REAL");

                    b.Property<double>("C4H10")
                        .HasColumnType("REAL");

                    b.Property<double>("C5H12")
                        .HasColumnType("REAL");

                    b.Property<double>("CH4")
                        .HasColumnType("REAL");

                    b.Property<double>("CO2")
                        .HasColumnType("REAL");

                    b.Property<double>("D")
                        .HasColumnType("REAL");

                    b.Property<double>("KPD")
                        .HasColumnType("REAL");

                    b.Property<double>("L")
                        .HasColumnType("REAL");

                    b.Property<double>("N2")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("ParPr")
                        .HasColumnType("REAL");

                    b.Property<double>("Tgv")
                        .HasColumnType("REAL");

                    b.Property<double>("Thv")
                        .HasColumnType("REAL");

                    b.Property<double>("Tpodgas")
                        .HasColumnType("REAL");

                    b.Property<double>("Tpodvosd")
                        .HasColumnType("REAL");

                    b.Property<double>("Tpp")
                        .HasColumnType("REAL");

                    b.Property<double>("Tpv")
                        .HasColumnType("REAL");

                    b.Property<double>("Tug")
                        .HasColumnType("REAL");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Vlagosod")
                        .HasColumnType("REAL");

                    b.Property<double>("WorkPressureOnDrum")
                        .HasColumnType("REAL");

                    b.Property<double>("WorkPressureOnExit")
                        .HasColumnType("REAL");

                    b.Property<double>("alfa")
                        .HasColumnType("REAL");

                    b.Property<double>("himnedog")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("ClassInputModeles");
                });

            modelBuilder.Entity("WebApplication.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
