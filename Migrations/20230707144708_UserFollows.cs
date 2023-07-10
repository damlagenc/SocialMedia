using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    /// <inheritdoc />
    public partial class UserFollows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_FollowerId",
                table: "UserUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_FollowingId",
                table: "UserUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUser",
                table: "UserUser");

            migrationBuilder.DropIndex(
                name: "IX_UserUser_FollowingId_FollowerId",
                table: "UserUser");

            migrationBuilder.RenameTable(
                name: "UserUser",
                newName: "UserFollows");

            migrationBuilder.RenameColumn(
                name: "FollowingId",
                table: "UserFollows",
                newName: "FollowingUserId");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                table: "UserFollows",
                newName: "FollowersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows",
                columns: new[] { "FollowersUserId", "FollowingUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollows_FollowingUserId",
                table: "UserFollows",
                column: "FollowingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_FollowersUserId",
                table: "UserFollows",
                column: "FollowersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_FollowingUserId",
                table: "UserFollows",
                column: "FollowingUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_FollowersUserId",
                table: "UserFollows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_FollowingUserId",
                table: "UserFollows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFollows",
                table: "UserFollows");

            migrationBuilder.DropIndex(
                name: "IX_UserFollows_FollowingUserId",
                table: "UserFollows");

            migrationBuilder.RenameTable(
                name: "UserFollows",
                newName: "UserUser");

            migrationBuilder.RenameColumn(
                name: "FollowingUserId",
                table: "UserUser",
                newName: "FollowingId");

            migrationBuilder.RenameColumn(
                name: "FollowersUserId",
                table: "UserUser",
                newName: "FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUser",
                table: "UserUser",
                columns: new[] { "FollowerId", "FollowingId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FollowingId_FollowerId",
                table: "UserUser",
                columns: new[] { "FollowingId", "FollowerId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_FollowerId",
                table: "UserUser",
                column: "FollowerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_FollowingId",
                table: "UserUser",
                column: "FollowingId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
