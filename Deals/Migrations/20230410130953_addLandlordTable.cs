using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deals.Migrations
{
    /// <inheritdoc />
    public partial class addLandlordTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandLordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlotSizeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SocietyBlocksBlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landlords_PlotSizes_PlotSizeId",
                        column: x => x.PlotSizeId,
                        principalTable: "PlotSizes",
                        principalColumn: "PlotSizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Landlords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Landlords_societyBlocks_SocietyBlocksBlockId",
                        column: x => x.SocietyBlocksBlockId,
                        principalTable: "societyBlocks",
                        principalColumn: "BlockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_PlotSizeId",
                table: "Landlords",
                column: "PlotSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_SocietyBlocksBlockId",
                table: "Landlords",
                column: "SocietyBlocksBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_UserId",
                table: "Landlords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Landlords");
        }
    }
}
