using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class EtourThird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_BookingHeaders_BookingId",
                table: "Passengers");

            migrationBuilder.DropTable(
                name: "BookingHeaders");

            migrationBuilder.DropTable(
                name: "CostMasters");

            migrationBuilder.DropTable(
                name: "DateMasters");

            migrationBuilder.CreateTable(
                name: "CostMaster",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    SinglePersonCost = table.Column<double>(type: "float", nullable: false),
                    ExtraPersonCost = table.Column<double>(type: "float", nullable: false),
                    ChildWithBed = table.Column<double>(type: "float", nullable: false),
                    ChildWithoutBed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostMaster", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "DateMaster",
                columns: table => new
                {
                    DepartureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfDays = table.Column<int>(type: "int", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMaster", x => x.DepartureId);
                    table.ForeignKey(
                        name: "FK_DateMaster_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingHeader",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfPassenger = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Taxes = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    DepartureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHeader", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingHeader_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                    table.ForeignKey(
                        name: "FK_BookingHeader_CustomerMaster_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerMaster",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_BookingHeader_DateMaster_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "DateMaster",
                        principalColumn: "DepartureId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeader_CustomerId",
                table: "BookingHeader",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeader_DepartureId",
                table: "BookingHeader",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeader_MasterId",
                table: "BookingHeader",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMaster_MasterId",
                table: "DateMaster",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers",
                column: "BookingId",
                principalTable: "BookingHeader",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_BookingHeader_BookingId",
                table: "Passengers");

            migrationBuilder.DropTable(
                name: "BookingHeader");

            migrationBuilder.DropTable(
                name: "CostMaster");

            migrationBuilder.DropTable(
                name: "DateMaster");

            migrationBuilder.CreateTable(
                name: "CostMasters",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildWithBed = table.Column<double>(type: "float", nullable: false),
                    ChildWithoutBed = table.Column<double>(type: "float", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    ExtraPersonCost = table.Column<double>(type: "float", nullable: false),
                    SinglePersonCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostMasters", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "DateMasters",
                columns: table => new
                {
                    DepartureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMasters", x => x.DepartureId);
                    table.ForeignKey(
                        name: "FK_DateMasters_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingHeaders",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    DepartureId = table.Column<int>(type: "int", nullable: true),
                    MasterId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfPassenger = table.Column<int>(type: "int", nullable: false),
                    Taxes = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHeaders", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingHeaders_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                    table.ForeignKey(
                        name: "FK_BookingHeaders_CustomerMaster_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerMaster",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_BookingHeaders_DateMasters_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "DateMasters",
                        principalColumn: "DepartureId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeaders_CustomerId",
                table: "BookingHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeaders_DepartureId",
                table: "BookingHeaders",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHeaders_MasterId",
                table: "BookingHeaders",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMasters_MasterId",
                table: "DateMasters",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_BookingHeaders_BookingId",
                table: "Passengers",
                column: "BookingId",
                principalTable: "BookingHeaders",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
