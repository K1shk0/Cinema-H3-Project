using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema2026.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddHallIdToSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "hallId",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hallId",
                table: "Seats");
        }
    }
}
