using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamFinderDAL.Migrations
{
    public partial class fix_lobby2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User-BoardGame");

            migrationBuilder.DropTable(
                name: "User-Friend");

            migrationBuilder.DropTable(
                name: "User-Lobby");

            migrationBuilder.CreateTable(
                name: "BoardGameUser",
                columns: table => new
                {
                    FavoredByUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavoriteGamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameUser", x => new { x.FavoredByUsersId, x.FavoriteGamesId });
                    table.ForeignKey(
                        name: "FK_BoardGameUser_AspNetUsers_FavoredByUsersId",
                        column: x => x.FavoredByUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameUser_BoardGames_FavoriteGamesId",
                        column: x => x.FavoriteGamesId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LobbyUser",
                columns: table => new
                {
                    ConnectedLobbiesId = table.Column<int>(type: "int", nullable: false),
                    ConnectedUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LobbyUser", x => new { x.ConnectedLobbiesId, x.ConnectedUsersId });
                    table.ForeignKey(
                        name: "FK_LobbyUser_AspNetUsers_ConnectedUsersId",
                        column: x => x.ConnectedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LobbyUser_Lobbies_ConnectedLobbiesId",
                        column: x => x.ConnectedLobbiesId,
                        principalTable: "Lobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FriendOfId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FriendsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FriendOfId, x.FriendsId });
                    table.ForeignKey(
                        name: "FK_UserUser_AspNetUsers_FriendOfId",
                        column: x => x.FriendOfId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_AspNetUsers_FriendsId",
                        column: x => x.FriendsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameUser_FavoriteGamesId",
                table: "BoardGameUser",
                column: "FavoriteGamesId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyUser_ConnectedUsersId",
                table: "LobbyUser",
                column: "ConnectedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FriendsId",
                table: "UserUser",
                column: "FriendsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameUser");

            migrationBuilder.DropTable(
                name: "LobbyUser");

            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.CreateTable(
                name: "User-BoardGame",
                columns: table => new
                {
                    BGameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User-BoardGame", x => new { x.BGameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_User-BoardGame_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User-BoardGame_BoardGames_BGameId",
                        column: x => x.BGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User-Friend",
                columns: table => new
                {
                    FriendId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User-Friend", x => new { x.FriendId, x.UserId });
                    table.ForeignKey(
                        name: "FK_User-Friend_AspNetUsers_FriendId",
                        column: x => x.FriendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User-Friend_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User-Lobby",
                columns: table => new
                {
                    LobbyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User-Lobby", x => new { x.LobbyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_User-Lobby_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User-Lobby_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User-BoardGame_UserId",
                table: "User-BoardGame",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User-Friend_UserId",
                table: "User-Friend",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User-Lobby_UserId",
                table: "User-Lobby",
                column: "UserId");
        }
    }
}
