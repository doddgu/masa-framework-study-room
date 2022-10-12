using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masa.EShop.Services.Catalog.Migrations
{
    public partial class SupportAuditAndSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "CatalogBrand",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Creator",
                table: "CatalogBrand",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CatalogBrand",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationTime",
                table: "CatalogBrand",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Modifier",
                table: "CatalogBrand",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Catalog",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Catalog",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Creator",
                table: "Catalog",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Catalog",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationTime",
                table: "Catalog",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Modifier",
                table: "Catalog",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "CatalogBrand");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "CatalogBrand");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CatalogBrand");

            migrationBuilder.DropColumn(
                name: "ModificationTime",
                table: "CatalogBrand");

            migrationBuilder.DropColumn(
                name: "Modifier",
                table: "CatalogBrand");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "ModificationTime",
                table: "Catalog");

            migrationBuilder.DropColumn(
                name: "Modifier",
                table: "Catalog");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Catalog",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
