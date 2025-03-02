using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Migrations
{
    /// <inheritdoc />
    public partial class AddingDecodeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameDecode",
                table: "ClothingItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameDecode",
                table: "ClothingItems");
        }
    }
}
