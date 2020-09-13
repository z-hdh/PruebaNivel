using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prueba.Data.Migrations
{
    public partial class addContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Products");
        }
    }
}
