using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fribergs_rentals_2.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTotalSumPropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Payement",
                table: "Bookings",
                newName: "TotalSum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSum",
                table: "Bookings",
                newName: "Payement");
        }
    }
}
