using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamFinderDAL.Migrations
{
    public partial class ChangeNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoardGames_BGameName",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "BGameName",
                table: "BoardGames");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MessageText",
                table: "Messages",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LobbyName",
                table: "Lobbies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LobbyId",
                table: "Lobbies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BGameId",
                table: "BoardGames",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BoardGames",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BoardGames");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Messages",
                newName: "MessageText");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Messages",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Lobbies",
                newName: "LobbyName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lobbies",
                newName: "LobbyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BoardGames",
                newName: "BGameId");

            migrationBuilder.AddColumn<string>(
                name: "BGameName",
                table: "BoardGames",
                type: "varchar(767)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_BGameName",
                table: "BoardGames",
                column: "BGameName",
                unique: true);
        }
    }
}
