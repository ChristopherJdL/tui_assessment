﻿// <auto-generated />
using CodeInsider.Tui.Assessment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace CodeInsider.Tui.Assessment.Migrations
{
    [DbContext(typeof(TuiDbContext))]
    [Migration("20180329223002_Recreated Data model")]
    partial class RecreatedDatamodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("CodeInsider.Tui.Assessment.Data.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IataCode");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("CodeInsider.Tui.Assessment.Data.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AirportId");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("CodeInsider.Tui.Assessment.Data.Flight", b =>
                {
                    b.HasOne("CodeInsider.Tui.Assessment.Data.Airport", "Airport")
                        .WithMany()
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
