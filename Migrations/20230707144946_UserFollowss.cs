using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Migrations
{
    /// <inheritdoc />
    public partial class UserFollowss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_FollowersUserId",
                table: "UserFollows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_FollowingUserId",
                table: "UserFollows");

            migrationBuilder.RenameColumn(
                name: "FollowingUserId",
                table: "UserFollows",
                newName: "FollowingId");

            migrationBuilder.RenameColumn(
                name: "FollowersUserId",
                table: "UserFollows",
                newName: "FollowerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollows_FollowingUserId",
                table: "UserFollows",
                newName: "IX_UserFollows_FollowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_FollowerId",
                table: "UserFollows",
                column: "FollowerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollows_Users_FollowingId",
                table: "UserFollows",
                column: "FollowingId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_FollowerId",
                table: "UserFollows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollows_Users_FollowingId",
                table: "UserFollows");

            migrationBuilder.RenameColumn(
                name: "FollowingId",
                table: "UserFollows",
                newName: "FollowingUserId");

            migrationBuilder.RenameColumn(
                name: "FollowerId",
                table: "UserFollows",
                newName: "FollowersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFollows_FollowingId",
                table: "UserFollows",
                newName: "IX_UserFollows_FollowingUserId");

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
    }
}
