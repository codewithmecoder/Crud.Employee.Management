﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Management.Migrations
{
    /// <inheritdoc />
    public partial class Db001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePhoto",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "Employees");
        }
    }
}
