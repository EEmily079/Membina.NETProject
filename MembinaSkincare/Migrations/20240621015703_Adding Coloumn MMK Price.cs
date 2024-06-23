﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MembinaSkincare.Migrations
{
    public partial class AddingColoumnMMKPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MMKPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MMKPrice",
                table: "Products");
        }
    }
}
