using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class daneLogowania2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Addresses_defaultAddressId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_defaultAddressId",
                table: "AppUsers");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Addresses_defaultAddressId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_defaultAddressId",
                table: "AppUsers");

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
        }
    }
}
