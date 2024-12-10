using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinemateAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class searchoptimization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieId",
                table: "Movies",
                column: "MovieId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieId",
                table: "Movies");
        }
    }
}
