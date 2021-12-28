using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamFinderDAL.Migrations
{
    public partial class AddedRatingColumnForUserAndDeletedNameColumnForLobby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Lobbies");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Users",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Lobbies",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
