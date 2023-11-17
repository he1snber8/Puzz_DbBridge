using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProjectBackend.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_User2Id",
                table: "Matches");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_User2Id_User1Id",
                table: "Matches",
                columns: new[] { "User2Id", "User1Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_Name",
                table: "Interests",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_User2Id_User1Id",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Interests_Name",
                table: "Interests");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_User2Id",
                table: "Matches",
                column: "User2Id");
        }
    }
}
