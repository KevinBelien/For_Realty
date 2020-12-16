using Microsoft.EntityFrameworkCore.Migrations;

namespace For_Realty.Migrations
{
    public partial class RealEstateTypeBugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                table: "RealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateTypeID",
                table: "RealEstate");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_RealEstateTypeID",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "RealEstateTypeID",
                table: "RealEstate");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                table: "RealEstate",
                column: "RealEstateSubtypeID",
                principalTable: "RealEstateSubtype",
                principalColumn: "RealEstateSubtypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                table: "RealEstate");

            migrationBuilder.AddColumn<int>(
                name: "RealEstateTypeID",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_RealEstateTypeID",
                table: "RealEstate",
                column: "RealEstateTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                table: "RealEstate",
                column: "RealEstateSubtypeID",
                principalTable: "RealEstateSubtype",
                principalColumn: "RealEstateSubtypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateTypeID",
                table: "RealEstate",
                column: "RealEstateTypeID",
                principalTable: "RealEstateType",
                principalColumn: "RealEstateTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
