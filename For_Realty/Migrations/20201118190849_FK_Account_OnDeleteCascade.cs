using Microsoft.EntityFrameworkCore.Migrations;

namespace For_Realty.Migrations
{
    public partial class FK_Account_OnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_AspNetUsers_UserID",
                table: "UserAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_AspNetUsers_UserID",
                table: "UserAccount",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_AspNetUsers_UserID",
                table: "UserAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_AspNetUsers_UserID",
                table: "UserAccount",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
