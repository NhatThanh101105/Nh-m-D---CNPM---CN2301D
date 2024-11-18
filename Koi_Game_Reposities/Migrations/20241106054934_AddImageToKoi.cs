using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koi_Game_Reposities.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToKoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
  

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "KoiFish",
                type: "nvarchar(max)",
                nullable: true);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
 
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "KoiFish");

        }
    }
}
