using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamFinderDAL.Migrations
{
    public partial class AddedLobbyLimitation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MaxNumberOfPlayers",
                table: "Lobbies",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MinNumberOfPlayers",
                table: "Lobbies",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MaxNumberOfPlayers",
                table: "BoardGames",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MinNumberOfPlayers",
                table: "BoardGames",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxNumberOfPlayers",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "MinNumberOfPlayers",
                table: "Lobbies");

            migrationBuilder.DropColumn(
                name: "MaxNumberOfPlayers",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "MinNumberOfPlayers",
                table: "BoardGames");
        }
    }
}
