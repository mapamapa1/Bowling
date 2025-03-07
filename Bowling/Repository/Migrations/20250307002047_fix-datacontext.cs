using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bowling.Repository.Migrations
{
    /// <inheritdoc />
    public partial class fixdatacontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Match_MatchID",
                table: "MatchPlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "MatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Matches_MatchID",
                table: "MatchPlayers",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayers_Matches_MatchID",
                table: "MatchPlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "MatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayers_Match_MatchID",
                table: "MatchPlayers",
                column: "MatchID",
                principalTable: "Match",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
