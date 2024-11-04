﻿// <auto-generated />
using System;
using Koi_Game_Reposities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Koi_Game_Reposities.Migrations
{
    [DbContext(typeof(KoiGameDatabaseContext))]
    partial class KoiGameDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("FoodId")
                        .HasName("PK__Food__856DB3EB5A5EED96");

                    b.ToTable("Food", (string)null);
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ItemType")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InventoryId")
                        .HasName("PK__Inventor__F5FDE6B38ACEE2A8");

                    b.HasIndex("PlayerId");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.KoiFish", b =>
                {
                    b.Property<int>("KoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KoiId"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("KoiName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Rare")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("KoiId")
                        .HasName("PK__KoiFish__E03435985BC48358");

                    b.ToTable("KoiFish", (string)null);
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<decimal?>("Coin")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<bool>("IsNewPlayer")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PlayerId")
                        .HasName("PK__Player__4A4E74C82A608C7A");

                    b.HasIndex(new[] { "UserName" }, "UQ__Player__C9F28456415A05F0")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.PlayerKoi", b =>
                {
                    b.Property<int>("PlayerKoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerKoiId"));

                    b.Property<int?>("KoiId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("PlayerKoiId")
                        .HasName("PK__PlayerKo__C89132A3A6886891");

                    b.HasIndex("KoiId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerKoi", (string)null);
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Pond", b =>
                {
                    b.Property<int>("PondId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PondId"));

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Size")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PondId")
                        .HasName("PK__Pond__D18BF834C18AC6C5");

                    b.ToTable("Pond", (string)null);
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.PondKoi", b =>
                {
                    b.Property<int>("PondKoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PondKoiId"));

                    b.Property<int>("PlayerKoiId")
                        .HasColumnType("int");

                    b.Property<int>("PondId")
                        .HasColumnType("int");

                    b.HasKey("PondKoiId");

                    b.HasIndex("PlayerKoiId");

                    b.HasIndex("PondId");

                    b.ToTable("PondKois");
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShopId"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ItemType")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("ShopId")
                        .HasName("PK__Shop__67C557C9004510DC");

                    b.ToTable("Shop", (string)null);
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Trade", b =>
                {
                    b.Property<int>("TradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TradeId"));

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int?>("KoiId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("TradeId")
                        .HasName("PK__Trade__3028BB5BB03C58D0");

                    b.HasIndex("BuyerId");

                    b.HasIndex("KoiId");

                    b.HasIndex("SellerId");

                    b.ToTable("Trade", (string)null);
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Upgrade", b =>
                {
                    b.Property<int>("UpgradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UpgradeId"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("UpgradeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UpgradeId")
                        .HasName("PK__Upgrades__CA188BE50EF5E1D5");

                    b.ToTable("Upgrades");
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Inventory", b =>
                {
                    b.HasOne("Koi_Game_Reposities.Entities.Player", "Player")
                        .WithMany("Inventories")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK__Inventory__Playe__4BAC3F29");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.PlayerKoi", b =>
                {
                    b.HasOne("Koi_Game_Reposities.Entities.KoiFish", "Koi")
                        .WithMany("PlayerKois")
                        .HasForeignKey("KoiId")
                        .HasConstraintName("FK__PlayerKoi__KoiId__3D5E1FD2");

                    b.HasOne("Koi_Game_Reposities.Entities.Player", "Player")
                        .WithMany("PlayerKois")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK__PlayerKoi__Playe__3C69FB99");

                    b.Navigation("Koi");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.PondKoi", b =>
                {
                    b.HasOne("Koi_Game_Reposities.Entities.PlayerKoi", "PlayerKoi")
                        .WithMany()
                        .HasForeignKey("PlayerKoiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Koi_Game_Reposities.Entities.Pond", "Pond")
                        .WithMany()
                        .HasForeignKey("PondId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerKoi");

                    b.Navigation("Pond");
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Trade", b =>
                {
                    b.HasOne("Koi_Game_Reposities.Entities.Player", "Buyer")
                        .WithMany("TradeBuyers")
                        .HasForeignKey("BuyerId")
                        .HasConstraintName("FK__Trade__BuyerId__47DBAE45");

                    b.HasOne("Koi_Game_Reposities.Entities.KoiFish", "Koi")
                        .WithMany("Trades")
                        .HasForeignKey("KoiId")
                        .HasConstraintName("FK__Trade__KoiId__48CFD27E");

                    b.HasOne("Koi_Game_Reposities.Entities.Player", "Seller")
                        .WithMany("TradeSellers")
                        .HasForeignKey("SellerId")
                        .HasConstraintName("FK__Trade__SellerId__46E78A0C");

                    b.Navigation("Buyer");

                    b.Navigation("Koi");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.KoiFish", b =>
                {
                    b.Navigation("PlayerKois");

                    b.Navigation("Trades");
                });

            modelBuilder.Entity("Koi_Game_Reposities.Entities.Player", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("PlayerKois");

                    b.Navigation("TradeBuyers");

                    b.Navigation("TradeSellers");
                });
#pragma warning restore 612, 618
        }
    }
}
