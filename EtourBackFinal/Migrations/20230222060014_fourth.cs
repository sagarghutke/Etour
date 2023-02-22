using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateMaster_CategoryMaster_MasterId",
                table: "DateMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Passengers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MasterId",
                table: "DateMaster",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DateMaster_CategoryMaster_MasterId",
                table: "DateMaster",
                column: "MasterId",
                principalTable: "CategoryMaster",
                principalColumn: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers",
                column: "BookingId",
                principalTable: "BookingHeader",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateMaster_CategoryMaster_MasterId",
                table: "DateMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MasterId",
                table: "DateMaster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DateMaster_CategoryMaster_MasterId",
                table: "DateMaster",
                column: "MasterId",
                principalTable: "CategoryMaster",
                principalColumn: "MasterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers",
                column: "BookingId",
                principalTable: "BookingHeader",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
