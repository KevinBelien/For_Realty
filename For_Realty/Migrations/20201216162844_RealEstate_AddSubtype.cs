using Microsoft.EntityFrameworkCore.Migrations;

namespace For_Realty.Migrations
{
    public partial class RealEstate_AddSubtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                table: "RealEstate");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                table: "RealEstate",
                column: "RealEstateSubtypeID",
                principalTable: "RealEstateSubtype",
                principalColumn: "RealEstateSubtypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                table: "RealEstate");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                table: "RealEstate",
                column: "RealEstateSubtypeID",
                principalTable: "RealEstateSubtype",
                principalColumn: "RealEstateSubtypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
