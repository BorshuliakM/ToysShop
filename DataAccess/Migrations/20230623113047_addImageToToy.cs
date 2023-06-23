using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToysShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addImageToToy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Toys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Toys");
        }
    }
}
