using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSLAManagementSystem.Data.SQLServer.Migrations
{
    public partial class InitialDBV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ControlPosts",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Buildings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AttendanceLogs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Adresses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ControlPosts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AttendanceLogs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Adresses");
        }
    }
}
