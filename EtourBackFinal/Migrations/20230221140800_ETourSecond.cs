using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class ETourSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHeaders_DateMasters_DepartureId",
                table: "BookingHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "DepartureId",
                table: "BookingHeaders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHeaders_DateMasters_DepartureId",
                table: "BookingHeaders",
                column: "DepartureId",
                principalTable: "DateMasters",
                principalColumn: "DepartureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHeaders_DateMasters_DepartureId",
                table: "BookingHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "DepartureId",
                table: "BookingHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHeaders_DateMasters_DepartureId",
                table: "BookingHeaders",
                column: "DepartureId",
                principalTable: "DateMasters",
                principalColumn: "DepartureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
