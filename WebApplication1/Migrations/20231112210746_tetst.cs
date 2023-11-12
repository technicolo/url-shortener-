using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class tetst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URLShort",
                table: "Urls",
                newName: "UrlShort");

            migrationBuilder.RenameColumn(
                name: "URLLong",
                table: "Urls",
                newName: "UrlLong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlShort",
                table: "Urls",
                newName: "URLShort");

            migrationBuilder.RenameColumn(
                name: "UrlLong",
                table: "Urls",
                newName: "URLLong");
        }
    }
}
