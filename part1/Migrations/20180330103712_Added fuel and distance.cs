using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeInsider.Tui.Assessment.Migrations
{
    public partial class Addedfuelanddistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FlightDistanceKilometers",
                table: "Flights",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FuelConsumptionLiters",
                table: "Flights",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightDistanceKilometers",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FuelConsumptionLiters",
                table: "Flights");
        }
    }
}
