using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koi_Game_Reposities.Migrations
{
    /// <inheritdoc />
    public partial class addNewCollumTrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerKoiId",
                table: "Trade",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnTrade",
                table: "PlayerKoi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Trade_PlayerKoiId",
                table: "Trade",
                column: "PlayerKoiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_PlayerKoi_PlayerKoiId",
                table: "Trade",
                column: "PlayerKoiId",
                principalTable: "PlayerKoi",
                principalColumn: "PlayerKoiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_PlayerKoi_PlayerKoiId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_PlayerKoiId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "PlayerKoiId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "IsOnTrade",
                table: "PlayerKoi");
        }
    }
}
