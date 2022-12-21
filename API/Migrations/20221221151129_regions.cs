using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class regions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_regions_AppUsers_courierId",
                        column: x => x.courierId,
                        principalTable: "AppUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "RegionPins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    x = table.Column<float>(type: "real", nullable: false),
                    y = table.Column<float>(type: "real", nullable: false),
                    regionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionPins", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegionPins_regions_regionId",
                        column: x => x.regionId,
                        principalTable: "regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionPins_regionId",
                table: "RegionPins",
                column: "regionId");

            migrationBuilder.CreateIndex(
                name: "IX_regions_courierId",
                table: "regions",
                column: "courierId",
                unique: true,
                filter: "[courierId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionPins");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
