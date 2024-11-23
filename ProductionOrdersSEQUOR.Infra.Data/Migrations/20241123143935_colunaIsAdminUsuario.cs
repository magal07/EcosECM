using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionOrderSEQUOR.Infra.Data.Migrations
{
    public partial class colunaIsAdminUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Usuario",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Usuario",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "User",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "User",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Usuario",
                newName: "passwordSalt");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Usuario",
                newName: "passwordHash");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
