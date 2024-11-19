using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koi_Game_Reposities.Migrations
{
    /// <inheritdoc />
    public partial class AddIsNewPlayerToPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Thêm cột IsNewPlayer vào bảng Player
            migrationBuilder.AddColumn<bool>(
                name: "IsNewPlayer",
                table: "Player", // Tên bảng phải khớp với tên bảng trong cơ sở dữ liệu
                nullable: false,
                defaultValue: true); // Giá trị mặc định cho cột này là true
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Xóa cột IsNewPlayer nếu migration bị hoàn tác
            migrationBuilder.DropColumn(
                name: "IsNewPlayer",
                table: "Player");
        }
    }
}

