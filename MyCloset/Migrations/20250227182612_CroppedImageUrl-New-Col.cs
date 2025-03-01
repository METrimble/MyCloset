using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Migrations
{
    /// <inheritdoc />
    public partial class CroppedImageUrlNewCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CroppedImageUrl",
                table: "ClothingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CroppedImageUrl",
                table: "ClothingItems");
        }
    }
}
