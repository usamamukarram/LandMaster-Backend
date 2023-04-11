using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deals.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSellerAndbuyerTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category_type",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Buyyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category_type",
                table: "Buyyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Buyyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Category_type",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Buyyers");

            migrationBuilder.DropColumn(
                name: "Category_type",
                table: "Buyyers");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Buyyers");
        }
    }
}
