using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GridScanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Hour1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour4 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour5 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour6 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour7 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour8 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour9 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour10 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour11 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour12 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour13 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour14 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour15 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour16 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour17 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour18 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour19 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour20 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour21 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour22 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour23 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hour24 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hour25 = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyPrices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyPrices");
        }
    }
}
