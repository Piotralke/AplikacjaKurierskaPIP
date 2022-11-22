using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AppUsers",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "AppUsers",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AppUsers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AppUsers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppUsers",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "login",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "login",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "password",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "AppUsers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "AppUsers",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AppUsers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "AppUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AppUsers",
                newName: "Id");
        }
    }
}
