using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace For_Realty.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    AgencyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    HouseNr = table.Column<string>(maxLength: 10, nullable: false),
                    Street = table.Column<string>(nullable: false),
                    ZIP = table.Column<string>(maxLength: 10, nullable: false),
                    Mail = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    BIV = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.AgencyID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyClass",
                columns: table => new
                {
                    EnergyClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Letter = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyClass", x => x.EnergyClassID);
                });

            migrationBuilder.CreateTable(
                name: "HeatingType",
                columns: table => new
                {
                    HeatingTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingType", x => x.HeatingTypeID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateStatus",
                columns: table => new
                {
                    RealEstateStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateStatus", x => x.RealEstateStatusID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateType",
                columns: table => new
                {
                    RealEstateTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateType", x => x.RealEstateTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    TownID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ZIP = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.TownID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    UserAccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Givenname = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    ZIP = table.Column<string>(maxLength: 10, nullable: true),
                    Street = table.Column<string>(nullable: true),
                    HouseNr = table.Column<string>(maxLength: 10, nullable: true),
                    Mail = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    AccountUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.UserAccountID);
                    table.ForeignKey(
                        name: "FK_UserAccount_AspNetUsers_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateSubtype",
                columns: table => new
                {
                    RealEstateSubtypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    RealEstateTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateSubtype", x => x.RealEstateSubtypeID);
                    table.ForeignKey(
                        name: "FK_RealEstateSubtype_RealEstateType_RealEstateTypeID",
                        column: x => x.RealEstateTypeID,
                        principalTable: "RealEstateType",
                        principalColumn: "RealEstateTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    AdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateInit = table.Column<DateTime>(nullable: false),
                    Requirements = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Radius = table.Column<int>(nullable: false),
                    UserAccountID = table.Column<int>(nullable: false),
                    TownID = table.Column<int>(nullable: false),
                    RealEstateTypeID = table.Column<int>(nullable: false),
                    RealEstateSubtypeID = table.Column<int>(nullable: true),
                    RealEstateStatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.AdID);
                    table.ForeignKey(
                        name: "FK_Ad_RealEstateStatus_RealEstateStatusID",
                        column: x => x.RealEstateStatusID,
                        principalTable: "RealEstateStatus",
                        principalColumn: "RealEstateStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ad_RealEstateSubtype_RealEstateSubtypeID",
                        column: x => x.RealEstateSubtypeID,
                        principalTable: "RealEstateSubtype",
                        principalColumn: "RealEstateSubtypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ad_RealEstateType_RealEstateTypeID",
                        column: x => x.RealEstateTypeID,
                        principalTable: "RealEstateType",
                        principalColumn: "RealEstateTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ad_Town_TownID",
                        column: x => x.TownID,
                        principalTable: "Town",
                        principalColumn: "TownID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ad_UserAccount_UserAccountID",
                        column: x => x.UserAccountID,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstate",
                columns: table => new
                {
                    RealEstateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    AmountBathrooms = table.Column<int>(nullable: true),
                    AmountBedrooms = table.Column<int>(nullable: true),
                    AmountToilets = table.Column<int>(nullable: true),
                    ConstructionYear = table.Column<int>(nullable: true),
                    AmountFacades = table.Column<int>(nullable: true),
                    HasParkingFacility = table.Column<bool>(nullable: true),
                    LivingArea = table.Column<int>(nullable: true),
                    AreaKitchen = table.Column<int>(nullable: true),
                    HasDressing = table.Column<bool>(nullable: true),
                    IsIsolated = table.Column<bool>(nullable: true),
                    HasTerrace = table.Column<bool>(nullable: true),
                    HasGarden = table.Column<bool>(nullable: true),
                    AreaSpace = table.Column<int>(nullable: false),
                    DescriptionTitle = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    HouseNr = table.Column<string>(maxLength: 10, nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    IsFloodArea = table.Column<bool>(nullable: false),
                    AmountOfFloors = table.Column<int>(nullable: true),
                    FloorLevel = table.Column<int>(nullable: true),
                    HasLift = table.Column<bool>(nullable: true),
                    HasAttic = table.Column<bool>(nullable: true),
                    Cadastral = table.Column<decimal>(nullable: false),
                    HasBuildingPermit = table.Column<bool>(nullable: true),
                    HeatingTypeID = table.Column<int>(nullable: true),
                    EnergyClassID = table.Column<int>(nullable: true),
                    RealEstateTypeID = table.Column<int>(nullable: false),
                    AgencyID = table.Column<int>(nullable: false),
                    RealEstateStatusID = table.Column<int>(nullable: false),
                    TownID = table.Column<int>(nullable: false),
                    RealEstateSubtypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstate", x => x.RealEstateID);
                    table.UniqueConstraint("AK_RealEstate", x => x.Code);
                    table.ForeignKey(
                        name: "FK_RealEstate_Agency_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "Agency",
                        principalColumn: "AgencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstate_EnergyClass_EnergyClassID",
                        column: x => x.EnergyClassID,
                        principalTable: "EnergyClass",
                        principalColumn: "EnergyClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstate_HeatingType_HeatingTypeID",
                        column: x => x.HeatingTypeID,
                        principalTable: "HeatingType",
                        principalColumn: "HeatingTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstate_RealEstateStatus_RealEstateStatusID",
                        column: x => x.RealEstateStatusID,
                        principalTable: "RealEstateStatus",
                        principalColumn: "RealEstateStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstate_RealEstateSubtype_RealEstateSubtypeID",
                        column: x => x.RealEstateSubtypeID,
                        principalTable: "RealEstateSubtype",
                        principalColumn: "RealEstateSubtypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstate_RealEstateType_RealEstateTypeID",
                        column: x => x.RealEstateTypeID,
                        principalTable: "RealEstateType",
                        principalColumn: "RealEstateTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstate_Town_TownID",
                        column: x => x.TownID,
                        principalTable: "Town",
                        principalColumn: "TownID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    FavoriteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealEstateID = table.Column<int>(nullable: false),
                    UserAccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.FavoriteID);
                    table.ForeignKey(
                        name: "FK_Favorite_RealEstate_RealEstateID",
                        column: x => x.RealEstateID,
                        principalTable: "RealEstate",
                        principalColumn: "RealEstateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorite_UserAccount_UserAccountID",
                        column: x => x.UserAccountID,
                        principalTable: "UserAccount",
                        principalColumn: "UserAccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePicture",
                columns: table => new
                {
                    RealEstatePictureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    RealEstateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePicture", x => x.RealEstatePictureID);
                    table.ForeignKey(
                        name: "FK_RealEstatePicture_RealEstate_RealEstateID",
                        column: x => x.RealEstateID,
                        principalTable: "RealEstate",
                        principalColumn: "RealEstateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ad_RealEstateStatusID",
                table: "Ad",
                column: "RealEstateStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_RealEstateSubtypeID",
                table: "Ad",
                column: "RealEstateSubtypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_RealEstateTypeID",
                table: "Ad",
                column: "RealEstateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_TownID",
                table: "Ad",
                column: "TownID");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_UserAccountID",
                table: "Ad",
                column: "UserAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_RealEstateID",
                table: "Favorite",
                column: "RealEstateID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_RealEstate",
                table: "Favorite",
                columns: new[] { "UserAccountID", "RealEstateID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_AgencyID",
                table: "RealEstate",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_EnergyClassID",
                table: "RealEstate",
                column: "EnergyClassID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_HeatingTypeID",
                table: "RealEstate",
                column: "HeatingTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_RealEstateStatusID",
                table: "RealEstate",
                column: "RealEstateStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_RealEstateSubtypeID",
                table: "RealEstate",
                column: "RealEstateSubtypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_RealEstateTypeID",
                table: "RealEstate",
                column: "RealEstateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_TownID",
                table: "RealEstate",
                column: "TownID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePicture_RealEstateID",
                table: "RealEstatePicture",
                column: "RealEstateID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateSubtype_RealEstateTypeID",
                table: "RealEstateSubtype",
                column: "RealEstateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_AccountUserId",
                table: "UserAccount",
                column: "AccountUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "RealEstatePicture");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "RealEstate");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "EnergyClass");

            migrationBuilder.DropTable(
                name: "HeatingType");

            migrationBuilder.DropTable(
                name: "RealEstateStatus");

            migrationBuilder.DropTable(
                name: "RealEstateSubtype");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "RealEstateType");
        }
    }
}
