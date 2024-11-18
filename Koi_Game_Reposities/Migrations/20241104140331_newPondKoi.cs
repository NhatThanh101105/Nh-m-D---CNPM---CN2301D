using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koi_Game_Reposities.Migrations
{
    /// <inheritdoc />
    public partial class newPondKoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PondKoi",
                columns: table => new
                {
                    PondKoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PondId = table.Column<int>(type: "int", nullable: false),
                    PlayerKoiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PondKoi", x => x.PondKoiId);
                    table.ForeignKey(
                        name: "FK_PondKoi_PlayerKoi_PlayerKoiId",
                        column: x => x.PlayerKoiId,
                        principalTable: "PlayerKoi",
                        principalColumn: "PlayerKoiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PondKoi_Pond_PondId",
                        column: x => x.PondId,
                        principalTable: "Pond",
                        principalColumn: "PondId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PondKoi_PlayerKoiId",
                table: "PondKoi",
                column: "PlayerKoiId");

            migrationBuilder.CreateIndex(
                name: "IX_PondKoi_PondId",
                table: "PondKoi",
                column: "PondId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PondKois");
        }
    }
}
