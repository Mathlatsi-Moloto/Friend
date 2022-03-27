using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsApplicationApi.Migrations
{
    public partial class FriendsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_Surname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    friend_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usersuser_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.friend_id);
                    table.ForeignKey(
                        name: "FK_Friends_users_usersuser_id",
                        column: x => x.usersuser_id,
                        principalTable: "users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_usersuser_id",
                table: "Friends",
                column: "usersuser_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
