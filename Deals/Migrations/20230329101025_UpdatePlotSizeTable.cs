using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deals.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlotSizeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "PlotSizes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "PlotSizes");
        }
    }
}
