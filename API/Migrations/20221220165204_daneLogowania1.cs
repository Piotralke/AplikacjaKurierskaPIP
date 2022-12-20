using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class daneLogowania1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "login",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "password",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "loginCredentialsId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoginCredentials",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCredentials", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_loginCredentialsId",
                table: "AppUsers",
                column: "loginCredentialsId",
                unique: true,
                filter: "[loginCredentialsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_LoginCredentials_loginCredentialsId",
                table: "AppUsers",
                column: "loginCredentialsId",
                principalTable: "LoginCredentials",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_LoginCredentials_loginCredentialsId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "LoginCredentials");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_loginCredentialsId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "loginCredentialsId",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
