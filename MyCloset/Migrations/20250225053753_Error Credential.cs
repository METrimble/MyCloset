using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCloset.Migrations
{
    /// <inheritdoc />
    public partial class ErrorCredential : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingItem",
                table: "ClothingItem");

            migrationBuilder.RenameTable(
                name: "ClothingItem",
                newName: "ClothingItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingItems",
                table: "ClothingItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingItems",
                table: "ClothingItems");

            migrationBuilder.RenameTable(
                name: "ClothingItems",
                newName: "ClothingItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingItem",
                table: "ClothingItem",
                column: "Id");
        }
    }
}
