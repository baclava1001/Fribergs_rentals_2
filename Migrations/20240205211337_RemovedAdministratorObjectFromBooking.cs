using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fribergs_rentals_2.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAdministratorObjectFromBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdministratorName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministratorName",
                table: "Bookings");
        }
    }
}
