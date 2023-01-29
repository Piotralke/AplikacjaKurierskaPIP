using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class packageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AppUsers_ReceiverId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AppUsers_SenderId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "regions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Packages",
                newName: "senderId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Packages",
                newName: "receiverId");

            migrationBuilder.RenameColumn(
                name: "CODcost",
                table: "Packages",
                newName: "cODcost");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_SenderId",
                table: "Packages",
                newName: "IX_Packages_senderId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_ReceiverId",
                table: "Packages",
                newName: "IX_Packages_receiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AppUsers_receiverId",
                table: "Packages",
                column: "receiverId",
                principalTable: "AppUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AppUsers_senderId",
                table: "Packages",
                column: "senderId",
                principalTable: "AppUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AppUsers_receiverId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AppUsers_senderId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "regions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "senderId",
                table: "Packages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "receiverId",
                table: "Packages",
                newName: "ReceiverId");

            migrationBuilder.RenameColumn(
                name: "cODcost",
                table: "Packages",
                newName: "CODcost");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_senderId",
                table: "Packages",
                newName: "IX_Packages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_receiverId",
                table: "Packages",
                newName: "IX_Packages_ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AppUsers_ReceiverId",
                table: "Packages",
                column: "ReceiverId",
                principalTable: "AppUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AppUsers_SenderId",
                table: "Packages",
                column: "SenderId",
                principalTable: "AppUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
