﻿// <auto-generated />
using System;
using For_Realty.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace For_Realty.Migrations
{
    [DbContext(typeof(For_RealtyDbContext))]
    [Migration("20201216162844_RealEstate_AddSubtype")]
    partial class RealEstate_AddSubtype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("For_Realty.Areas.Identity.Data.AccountUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("For_Realty.Models.Ad", b =>
                {
                    b.Property<int>("AdID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInit")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("Radius")
                        .HasColumnType("int");

                    b.Property<int>("RealEstateStatusID")
                        .HasColumnType("int");

                    b.Property<int?>("RealEstateSubtypeID")
                        .HasColumnType("int");

                    b.Property<int>("RealEstateTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TownID")
                        .HasColumnType("int");

                    b.Property<int>("UserAccountID")
                        .HasColumnType("int");

                    b.HasKey("AdID");

                    b.HasIndex("RealEstateStatusID");

                    b.HasIndex("RealEstateSubtypeID");

                    b.HasIndex("RealEstateTypeID");

                    b.HasIndex("TownID");

                    b.HasIndex("UserAccountID");

                    b.ToTable("Ad");
                });

            modelBuilder.Entity("For_Realty.Models.Agency", b =>
                {
                    b.Property<int>("AgencyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BIV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("AgencyID");

                    b.ToTable("Agency");
                });

            modelBuilder.Entity("For_Realty.Models.EnergyClass", b =>
                {
                    b.Property<int>("EnergyClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Letter")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("EnergyClassID");

                    b.ToTable("EnergyClass");
                });

            modelBuilder.Entity("For_Realty.Models.Favorite", b =>
                {
                    b.Property<int>("FavoriteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RealEstateID")
                        .HasColumnType("int");

                    b.Property<int>("UserAccountID")
                        .HasColumnType("int");

                    b.HasKey("FavoriteID");

                    b.HasIndex("RealEstateID");

                    b.HasIndex("UserAccountID", "RealEstateID")
                        .IsUnique()
                        .HasName("IX_UserAccount_RealEstate");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("For_Realty.Models.HeatingType", b =>
                {
                    b.Property<int>("HeatingTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("HeatingTypeID");

                    b.ToTable("HeatingType");
                });

            modelBuilder.Entity("For_Realty.Models.RealEstate", b =>
                {
                    b.Property<int>("RealEstateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgencyID")
                        .HasColumnType("int");

                    b.Property<int?>("AmountBathrooms")
                        .HasColumnType("int");

                    b.Property<int?>("AmountBedrooms")
                        .HasColumnType("int");

                    b.Property<int?>("AmountFacades")
                        .HasColumnType("int");

                    b.Property<int?>("AmountOfFloors")
                        .HasColumnType("int");

                    b.Property<int?>("AmountToilets")
                        .HasColumnType("int");

                    b.Property<int?>("AreaKitchen")
                        .HasColumnType("int");

                    b.Property<int>("AreaSpace")
                        .HasColumnType("int");

                    b.Property<decimal?>("Cadastral")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int?>("ConstructionYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateInit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("EnergyClassID")
                        .HasColumnType("int");

                    b.Property<int?>("FloorLevel")
                        .HasColumnType("int");

                    b.Property<bool?>("HasAttic")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasBuildingPermit")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasDressing")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasGarden")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasLift")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasParkingFacility")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasTerrace")
                        .HasColumnType("bit");

                    b.Property<int?>("HeatingTypeID")
                        .HasColumnType("int");

                    b.Property<string>("HouseNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<bool>("IsFloodArea")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsIsolated")
                        .HasColumnType("bit");

                    b.Property<int?>("LivingArea")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("RealEstateStatusID")
                        .HasColumnType("int");

                    b.Property<int>("RealEstateSubtypeID")
                        .HasColumnType("int");

                    b.Property<int>("RealEstateTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TownID")
                        .HasColumnType("int");

                    b.HasKey("RealEstateID");

                    b.HasAlternateKey("Code")
                        .HasName("AK_RealEstate_Code");

                    b.HasIndex("AgencyID");

                    b.HasIndex("EnergyClassID");

                    b.HasIndex("HeatingTypeID");

                    b.HasIndex("RealEstateStatusID");

                    b.HasIndex("RealEstateSubtypeID");

                    b.HasIndex("RealEstateTypeID");

                    b.HasIndex("TownID");

                    b.ToTable("RealEstate");
                });

            modelBuilder.Entity("For_Realty.Models.RealEstatePicture", b =>
                {
                    b.Property<int>("RealEstatePictureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RealEstateID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RealEstatePictureID");

                    b.HasIndex("RealEstateID");

                    b.ToTable("RealEstatePicture");
                });

            modelBuilder.Entity("For_Realty.Models.RealEstateStatus", b =>
                {
                    b.Property<int>("RealEstateStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RealEstateStatusID");

                    b.ToTable("RealEstateStatus");
                });

            modelBuilder.Entity("For_Realty.Models.RealEstateSubtype", b =>
                {
                    b.Property<int>("RealEstateSubtypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RealEstateTypeID")
                        .HasColumnType("int");

                    b.HasKey("RealEstateSubtypeID");

                    b.HasIndex("RealEstateTypeID");

                    b.ToTable("RealEstateSubtype");
                });

            modelBuilder.Entity("For_Realty.Models.RealEstateType", b =>
                {
                    b.Property<int>("RealEstateTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RealEstateTypeID");

                    b.ToTable("RealEstateType");
                });

            modelBuilder.Entity("For_Realty.Models.Town", b =>
                {
                    b.Property<int>("TownID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("TownID");

                    b.ToTable("Town");
                });

            modelBuilder.Entity("For_Realty.Models.UserAccount", b =>
                {
                    b.Property<int>("UserAccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Givenname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNr")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ZIP")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("UserAccountID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("UserAccount");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("For_Realty.Models.Ad", b =>
                {
                    b.HasOne("For_Realty.Models.RealEstateStatus", "RealEstateStatus")
                        .WithMany("Ads")
                        .HasForeignKey("RealEstateStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("For_Realty.Models.RealEstateSubtype", "RealEstateSubtype")
                        .WithMany("Ads")
                        .HasForeignKey("RealEstateSubtypeID");

                    b.HasOne("For_Realty.Models.RealEstateType", "RealEstateType")
                        .WithMany("Ads")
                        .HasForeignKey("RealEstateTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("For_Realty.Models.Town", "Town")
                        .WithMany("Ads")
                        .HasForeignKey("TownID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("For_Realty.Models.UserAccount", "UserAccount")
                        .WithMany("Ads")
                        .HasForeignKey("UserAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("For_Realty.Models.Favorite", b =>
                {
                    b.HasOne("For_Realty.Models.RealEstate", "RealEstate")
                        .WithMany("Favorites")
                        .HasForeignKey("RealEstateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("For_Realty.Models.UserAccount", "UserAccount")
                        .WithMany("Favorites")
                        .HasForeignKey("UserAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("For_Realty.Models.RealEstate", b =>
                {
                    b.HasOne("For_Realty.Models.Agency", "Agency")
                        .WithMany("RealEstates")
                        .HasForeignKey("AgencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("For_Realty.Models.EnergyClass", "EnergyClass")
                        .WithMany("RealEstates")
                        .HasForeignKey("EnergyClassID");

                    b.HasOne("For_Realty.Models.HeatingType", "HeatingType")
                        .WithMany("RealEstates")
                        .HasForeignKey("HeatingTypeID");

                    b.HasOne("For_Realty.Models.RealEstateStatus", "RealEstateStatus")
                        .WithMany("RealEstates")
                        .HasForeignKey("RealEstateStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("For_Realty.Models.RealEstateSubtype", "RealEstateSubtype")
                        .WithMany("RealEstates")
                        .HasForeignKey("RealEstateSubtypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("For_Realty.Models.RealEstateType", "RealEstateType")
                        .WithMany("RealEstates")
                        .HasForeignKey("RealEstateTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("For_Realty.Models.Town", "Town")
                        .WithMany("RealEstates")
                        .HasForeignKey("TownID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("For_Realty.Models.RealEstatePicture", b =>
                {
                    b.HasOne("For_Realty.Models.RealEstate", "RealEstate")
                        .WithMany("RealEstatePictures")
                        .HasForeignKey("RealEstateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("For_Realty.Models.RealEstateSubtype", b =>
                {
                    b.HasOne("For_Realty.Models.RealEstateType", "RealEstateType")
                        .WithMany("RealEstateSubtypes")
                        .HasForeignKey("RealEstateTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("For_Realty.Models.UserAccount", b =>
                {
                    b.HasOne("For_Realty.Areas.Identity.Data.AccountUser", "AccountUser")
                        .WithOne("UserAccount")
                        .HasForeignKey("For_Realty.Models.UserAccount", "UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("For_Realty.Areas.Identity.Data.AccountUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("For_Realty.Areas.Identity.Data.AccountUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("For_Realty.Areas.Identity.Data.AccountUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("For_Realty.Areas.Identity.Data.AccountUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
