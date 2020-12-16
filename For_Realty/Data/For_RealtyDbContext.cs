using System;
using System.Collections.Generic;
using System.Text;
using For_Realty.Areas.Identity.Data;
using For_Realty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace For_Realty.Data
{
    public class For_RealtyDbContext : IdentityDbContext<AccountUser>
    {
        public For_RealtyDbContext(DbContextOptions<For_RealtyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<EnergyClass> EnergyClasses { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<HeatingType> HeatingTypes { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<RealEstatePicture> RealEstatePictures { get; set; }
        public DbSet<RealEstateStatus> RealEstateStatuses { get; set; }
        public DbSet<RealEstateSubtype> RealEstateSubtypes { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            OnModelCreatingAd(builder);
            OnModelCreatingAgency(builder);
            OnModelCreatingEnergyClass(builder);
            OnModelCreatingFavorite(builder);
            OnModelCreatingHeatingType(builder);
            OnModelCreatingRealEstate(builder);
            OnModelCreatingRealEstatePicture(builder);
            OnModelCreatingRealEstateStatus(builder);
            OnModelCreatingRealEstateSubtype(builder);
            OnModelCreatingRealEstateType(builder);
            OnModelCreatingTown(builder);
            OnModelCreatingUserAccount(builder);
            OnModelCreatingForeignKeyAccount(builder);
        }

        private void OnModelCreatingAgency(ModelBuilder builder)
        {
            builder.Entity<Agency>().ToTable("Agency");
            builder.Entity<Agency>().Property(a => a.HouseNr).HasMaxLength(10)
                .IsRequired();
            builder.Entity<Agency>().Property(a => a.ZIP).HasMaxLength(10)
                .IsRequired();
            builder.Entity<Agency>().Property(a => a.Name).IsRequired();
            builder.Entity<Agency>().Property(a => a.City).IsRequired();
            builder.Entity<Agency>().Property(a => a.HouseNr).IsRequired();
            builder.Entity<Agency>().Property(a => a.Street).IsRequired();
            builder.Entity<Agency>().Property(a => a.Mail).IsRequired();
            builder.Entity<Agency>().Property(a => a.Phone).IsRequired();
            builder.Entity<Agency>().Property(a => a.BIV).IsRequired();
        }
        private void OnModelCreatingRealEstate(ModelBuilder builder)
        {
            builder.Entity<RealEstate>().ToTable("RealEstate");
            builder.Entity<RealEstate>().Property(r => r.Code).IsRequired().HasMaxLength(15);
            builder.Entity<RealEstate>().HasAlternateKey(r => r.Code)
                .HasName("AK_RealEstate_Code");
            builder.Entity<RealEstate>().Property(r => r.DescriptionTitle).HasMaxLength(100)
                .IsRequired();
            builder.Entity<RealEstate>().Property(r => r.HouseNr).HasMaxLength(10)
                .IsRequired();    
            builder.Entity<RealEstate>().Property(r => r.AreaSpace).IsRequired();
            builder.Entity<RealEstate>().Property(r => r.Description).IsRequired();
            builder.Entity<RealEstate>().Property(r => r.Street).IsRequired();
            builder.Entity<RealEstate>().Property(r => r.Price).HasColumnType("decimal(10, 2)").IsRequired();
            builder.Entity<RealEstate>().Property(r => r.IsFloodArea).IsRequired();
            builder.Entity<RealEstate>().Property(r => r.Cadastral).HasColumnType("decimal(8, 2)");
            builder.Entity<RealEstate>().Property(r => r.DateInit).IsRequired();

            builder.Entity<RealEstate>()
                .HasOne(r => r.RealEstateSubtype)
                .WithMany(st => st.RealEstates)
                .HasForeignKey(r => r.RealEstateSubtypeID)
                .OnDelete(DeleteBehavior.Restrict);

        }

        private void OnModelCreatingAd(ModelBuilder builder)
        {
            builder.Entity<Ad>().ToTable("Ad");
            builder.Entity<Ad>().Property(a => a.DateInit).IsRequired();
            builder.Entity<Ad>().Property(a => a.Price).HasColumnType("decimal(10, 2)").IsRequired();
            builder.Entity<Ad>().Property(a => a.Radius).IsRequired();
        }
        private void OnModelCreatingEnergyClass(ModelBuilder builder)
        {
            builder.Entity<EnergyClass>().ToTable("EnergyClass");
            builder.Entity<EnergyClass>().Property(e => e.Letter).HasMaxLength(10).IsRequired();
        }

        private void OnModelCreatingFavorite(ModelBuilder builder)
        {
            builder.Entity<Favorite>().ToTable("Favorite");
            builder.Entity<Favorite>().HasIndex(f => new { f.UserAccountID, f.RealEstateID})
                .HasName("IX_UserAccount_RealEstate")
                .IsUnique();
        }

        private void OnModelCreatingHeatingType(ModelBuilder builder)
        {
            builder.Entity<HeatingType>().ToTable("HeatingType");
            builder.Entity<HeatingType>().Property(h => h.Name).HasMaxLength(50).IsRequired();
        }

        private void OnModelCreatingRealEstatePicture(ModelBuilder builder)
        {
            builder.Entity<RealEstatePicture>().ToTable("RealEstatePicture");
            builder.Entity<RealEstatePicture>().Property(p => p.FileName).IsRequired();
        }

        private void OnModelCreatingRealEstateStatus(ModelBuilder builder)
        {
            builder.Entity<RealEstateStatus>().ToTable("RealEstateStatus");
            builder.Entity<RealEstateStatus>().Property(s => s.Status).IsRequired();
        }

        private void OnModelCreatingRealEstateSubtype(ModelBuilder builder)
        {
            builder.Entity<RealEstateSubtype>().ToTable("RealEstateSubtype");
            builder.Entity<RealEstateSubtype>().Property(s => s.Name).IsRequired();
        }

        private void OnModelCreatingRealEstateType(ModelBuilder builder)
        {
            builder.Entity<RealEstateType>().ToTable("RealEstateType");
            builder.Entity<RealEstateType>().Property(s => s.Name).IsRequired();
        }

        private void OnModelCreatingTown(ModelBuilder builder)
        {
            builder.Entity<Town>().ToTable("Town");
            builder.Entity<Town>().Property(t => t.Name).IsRequired();
            builder.Entity<Town>().Property(t => t.ZIP).HasMaxLength(10)
                .IsRequired();
        }

        private void OnModelCreatingUserAccount(ModelBuilder builder)
        {
            builder.Entity<UserAccount>().ToTable("UserAccount");
            builder.Entity<UserAccount>().Property(u => u.Givenname).IsRequired();
            builder.Entity<UserAccount>().Property(u => u.Surname).IsRequired();
            builder.Entity<UserAccount>().Ignore(u => u.FullName);
            builder.Entity<UserAccount>().Property(u => u.HouseNr).HasMaxLength(10);
            builder.Entity<UserAccount>().Property(u => u.ZIP).HasMaxLength(10);
        }

        private void OnModelCreatingForeignKeyAccount(ModelBuilder builder)
        {
            builder.Entity<AccountUser>()
                .HasOne(u => u.UserAccount)
                .WithOne(a => a.AccountUser)
                .HasForeignKey<UserAccount>(u => u.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
