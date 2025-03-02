using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Migrations
{
    /// <inheritdoc />
    public partial class AddClothingTypeEnum2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ClothingItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ClothingItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
