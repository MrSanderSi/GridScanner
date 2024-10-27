using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GridScanner.Data.Migrations
{
    /// <inheritdoc />
    public partial class DbModelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightedAvg",
                table: "DaysData",
                newName: "Avg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avg",
                table: "DaysData",
                newName: "WeightedAvg");
        }
    }
}
