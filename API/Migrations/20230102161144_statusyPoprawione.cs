using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class statusyPoprawione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Statuses_idStatusName",
                table: "Statuses");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_idStatusName",
                table: "Statuses",
                column: "idStatusName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Statuses_idStatusName",
                table: "Statuses");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_idStatusName",
                table: "Statuses",
                column: "idStatusName",
                unique: true);
        }
    }
}
