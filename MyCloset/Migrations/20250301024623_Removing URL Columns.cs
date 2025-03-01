using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Migrations
{
    /// <inheritdoc />
    public partial class RemovingURLColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CroppedImageUrl",
                table: "ClothingItems");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ClothingItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CroppedImageUrl",
                table: "ClothingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ClothingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
