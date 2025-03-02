using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Migrations
{
    /// <inheritdoc />
    public partial class AddImageNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CroppedImageName",
                table: "ClothingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ClothingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CroppedImageName",
                table: "ClothingItems");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ClothingItems");
        }
    }
}
