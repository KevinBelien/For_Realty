using Microsoft.EntityFrameworkCore.Migrations;

namespace For_Realty.Migrations
{
    public partial class RemovePhoneAndMailFromUserAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "UserAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
