using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Example.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Incentives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(13,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleIncentive",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    IncentiveId = table.Column<int>(type: "int", nullable: false),
                    ValidTill = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleIncentive", x => new { x.IncentiveId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_VehicleIncentive_Incentives_IncentiveId",
                        column: x => x.IncentiveId,
                        principalTable: "Incentives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleIncentive_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ColorId",
                table: "Inventories",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_VehicleId",
                table: "Inventories",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleIncentive_VehicleId",
                table: "VehicleIncentive",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "VehicleIncentive");
        }
    }
}
