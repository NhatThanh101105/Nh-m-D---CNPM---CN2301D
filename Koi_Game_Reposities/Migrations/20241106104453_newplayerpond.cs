using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koi_Game_Reposities.Migrations
{
    public partial class newplayerpond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Xóa các khóa ngoại cũ
            migrationBuilder.DropForeignKey(
                name: "FK_PondKoi_PlayerKoi_PlayerKoiId",
                table: "PondKoi");

            migrationBuilder.DropForeignKey(
                name: "FK_PondKoi_Pond_PondId",
                table: "PondKoi");

            // Thêm cột 'Level' vào bảng 'Pond'
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Pond",
                type: "int",
                nullable: false,
                defaultValue: 1);

            // Thay đổi kiểu dữ liệu cột 'PondId' trong 'PondKoi' từ không nullable thành nullable
            migrationBuilder.AlterColumn<int>(
                name: "PondId",
                table: "PondKoi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            // Thêm cột 'PlayerPondId' vào bảng 'PondKoi'
            migrationBuilder.AddColumn<int>(
                name: "PlayerPondId",
                table: "PondKoi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Tạo bảng 'PlayerPond' mới
            migrationBuilder.CreateTable(
                name: "PlayerPond",
                columns: table => new
                {
                    PlayerPondId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PondId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPond", x => x.PlayerPondId);
                    table.ForeignKey(
                        name: "FK_PlayerPond_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPond_Pond_PondId",
                        column: x => x.PondId,
                        principalTable: "Pond",
                        principalColumn: "PondId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Tạo các chỉ mục mới
            migrationBuilder.CreateIndex(
                name: "IX_PondKoi_PlayerPondId",
                table: "PondKoi",
                column: "PlayerPondId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPond_PlayerId",
                table: "PlayerPond",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPond_PondId",
                table: "PlayerPond",
                column: "PondId");

            // Thêm các khóa ngoại mới
            migrationBuilder.AddForeignKey(
                name: "FK_PondKoi_PlayerKoi_PlayerKoiId",
                table: "PondKoi",
                column: "PlayerKoiId",
                principalTable: "PlayerKoi",
                principalColumn: "PlayerKoiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PondKoi_PlayerPond_PlayerPondId",
                table: "PondKoi",
                column: "PlayerPondId",
                principalTable: "PlayerPond",
                principalColumn: "PlayerPondId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PondKoi_Pond_PondId",
                table: "PondKoi",
                column: "PondId",
                principalTable: "Pond",
                principalColumn: "PondId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Xóa các khóa ngoại
            migrationBuilder.DropForeignKey(
                name: "FK_PondKoi_PlayerKoi_PlayerKoiId",
                table: "PondKoi");

            migrationBuilder.DropForeignKey(
                name: "FK_PondKoi_PlayerPond_PlayerPondId",
                table: "PondKoi");

            migrationBuilder.DropForeignKey(
                name: "FK_PondKoi_Pond_PondId",
                table: "PondKoi");

            // Xóa bảng 'PlayerPond'
            migrationBuilder.DropTable(
                name: "PlayerPond");

            // Xóa chỉ mục
            migrationBuilder.DropIndex(
                name: "IX_PondKoi_PlayerPondId",
                table: "PondKoi");

            // Xóa các cột mới
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Pond");

            migrationBuilder.DropColumn(
                name: "PlayerPondId",
                table: "PondKoi");

            // Thêm các khóa ngoại trở lại
            migrationBuilder.AddForeignKey(
                name: "FK_PondKoi_PlayerKoi_PlayerKoiId",
                table: "PondKoi",
                column: "PlayerKoiId",
                principalTable: "PlayerKoi",
                principalColumn: "PlayerKoiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PondKoi_Pond_PondId",
                table: "PondKoi",
                column: "PondId",
                principalTable: "Pond",
                principalColumn: "PondId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
