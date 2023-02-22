using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtourBackFinal.Migrations
{
    /// <inheritdoc />
    public partial class ETourFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryMaster",
                columns: table => new
                {
                    MasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SubcategoryId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ToNewTab = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMaster", x => x.MasterId);
                });

            migrationBuilder.CreateTable(
                name: "CostMasters",
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
                    table.PrimaryKey("PK_CostMasters", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMaster",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Create_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMaster", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DateMasters",
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
                    table.PrimaryKey("PK_DateMasters", x => x.DepartureId);
                    table.ForeignKey(
                        name: "FK_DateMasters_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItneraryMaster",
                columns: table => new
                {
                    ItneraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfDays = table.Column<int>(type: "int", nullable: false),
                    Itnearydetails = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItneraryMaster", x => x.ItneraryId);
                    table.ForeignKey(
                        name: "FK_ItneraryMaster_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Packages_CategoryMaster_MasterId",
                        column: x => x.MasterId,
                        principalTable: "CategoryMaster",
                        principalColumn: "MasterId");
                });

            migrationBuilder.CreateTable(
                name: "BookingHeaders",
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
                    DepartureId = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "DepartureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Passengertype = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PassengerAmount = table.Column<double>(type: "float", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_Passengers_BookingHeaders_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BookingHeaders",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_ItneraryMaster_MasterId",
                table: "ItneraryMaster",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_MasterId",
                table: "Packages",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostMasters");

            migrationBuilder.DropTable(
                name: "ItneraryMaster");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "BookingHeaders");

            migrationBuilder.DropTable(
                name: "CustomerMaster");

            migrationBuilder.DropTable(
                name: "DateMasters");

            migrationBuilder.DropTable(
                name: "CategoryMaster");
        }
    }
}
