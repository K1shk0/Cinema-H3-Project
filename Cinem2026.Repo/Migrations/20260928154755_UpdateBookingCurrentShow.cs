using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema2026.Repo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingCurrentShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "Bookings",
                newName: "currentShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "currentShowId",
                table: "Bookings",
                newName: "movieId");
        }
    }
}
