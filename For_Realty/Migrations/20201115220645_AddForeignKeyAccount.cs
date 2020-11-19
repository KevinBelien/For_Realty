using Microsoft.EntityFrameworkCore.Migrations;

namespace For_Realty.Migrations
{
    public partial class AddForeignKeyAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_AspNetUsers_AccountUserId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_AccountUserId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "AccountUserId",
                table: "UserAccount");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserAccount",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_UserID",
                table: "UserAccount",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_AspNetUsers_UserID",
                table: "UserAccount",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_AspNetUsers_UserID",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_UserID",
                table: "UserAccount");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountUserId",
                table: "UserAccount",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_AccountUserId",
                table: "UserAccount",
                column: "AccountUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_AspNetUsers_AccountUserId",
                table: "UserAccount",
                column: "AccountUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
