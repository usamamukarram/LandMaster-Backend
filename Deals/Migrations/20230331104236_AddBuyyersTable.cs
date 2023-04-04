using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deals.Migrations
{
    /// <inheritdoc />
    public partial class AddBuyyersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlotSizeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SocietyBlocksBlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyyers_PlotSizes_PlotSizeId",
                        column: x => x.PlotSizeId,
                        principalTable: "PlotSizes",
                        principalColumn: "PlotSizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buyyers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buyyers_societyBlocks_SocietyBlocksBlockId",
                        column: x => x.SocietyBlocksBlockId,
                        principalTable: "societyBlocks",
                        principalColumn: "BlockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyyers_PlotSizeId",
                table: "Buyyers",
                column: "PlotSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyyers_SocietyBlocksBlockId",
                table: "Buyyers",
                column: "SocietyBlocksBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyyers_UserId",
                table: "Buyyers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyyers");
        }
    }
}
