using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToysShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyForCategoryProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Toys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Toys_CategoryId",
                table: "Toys",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Categories_CategoryId",
                table: "Toys",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Categories_CategoryId",
                table: "Toys");

            migrationBuilder.DropIndex(
                name: "IX_Toys_CategoryId",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Toys");
        }
    }
}
