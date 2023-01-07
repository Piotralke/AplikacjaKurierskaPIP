using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Addresses_defaultAddressId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AppUsers_courierId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_defaultAddressId",
                table: "AppUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Statuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "courierId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "defaultAddressId",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_defaultAddressId",
                table: "AppUsers",
                column: "defaultAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Addresses_defaultAddressId",
                table: "AppUsers",
                column: "defaultAddressId",
                principalTable: "Addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AppUsers_courierId",
                table: "Orders",
                column: "courierId",
                principalTable: "AppUsers",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Addresses_defaultAddressId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AppUsers_courierId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_defaultAddressId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Statuses");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "courierId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "defaultAddressId",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_defaultAddressId",
                table: "AppUsers",
                column: "defaultAddressId",
                unique: true,
                filter: "[defaultAddressId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Addresses_defaultAddressId",
                table: "AppUsers",
                column: "defaultAddressId",
                principalTable: "Addresses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AppUsers_courierId",
                table: "Orders",
                column: "courierId",
                principalTable: "AppUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
