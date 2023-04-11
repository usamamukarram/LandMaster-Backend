using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deals.Migrations
{
    /// <inheritdoc />
    public partial class updateLandlordTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "Landlords",
                newName: "Plotno");

            migrationBuilder.AddColumn<string>(
                name: "Demand",
                table: "Landlords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Demand",
                table: "Landlords");

            migrationBuilder.RenameColumn(
                name: "Plotno",
                table: "Landlords",
                newName: "Budget");
        }
    }
}
