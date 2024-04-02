using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBigStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categori_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categori",
                table: "Categori");

            migrationBuilder.RenameTable(
                name: "Categori",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categori");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categori",
                table: "Categori",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categori_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
