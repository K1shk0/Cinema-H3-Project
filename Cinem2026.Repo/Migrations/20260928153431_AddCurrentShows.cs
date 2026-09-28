using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema2026.Repo.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentShows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentShows",
                columns: table => new
                {
                    currentShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieId = table.Column<int>(type: "int", nullable: false),
                    hallId = table.Column<int>(type: "int", nullable: false),
                    showDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentShows", x => x.currentShowId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentShows");
        }
    }
}
