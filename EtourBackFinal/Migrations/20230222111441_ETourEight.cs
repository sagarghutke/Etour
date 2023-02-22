using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class ETourEight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterId",
                table: "CostMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostMaster_MasterId",
                table: "CostMaster",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostMaster_CategoryMaster_MasterId",
                table: "CostMaster",
                column: "MasterId",
                principalTable: "CategoryMaster",
                principalColumn: "MasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostMaster_CategoryMaster_MasterId",
                table: "CostMaster");

            migrationBuilder.DropIndex(
                name: "IX_CostMaster_MasterId",
                table: "CostMaster");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "CostMaster");
        }
    }
}
