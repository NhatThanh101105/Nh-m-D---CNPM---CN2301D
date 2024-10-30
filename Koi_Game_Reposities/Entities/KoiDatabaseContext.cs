using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Koi_Game_Reposities.Entities;

public partial class KoiDatabaseContext : DbContext
{
    public KoiDatabaseContext()
    {
    }

    public KoiDatabaseContext(DbContextOptions<KoiDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerKoiFish> PlayerKoiFishes { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HAI2\\SQLEXPRESS; DataBase=koi_database;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__Food__B350047CE4E0B6DB");

            entity.ToTable("Food");

            entity.Property(e => e.FoodId)
                .HasMaxLength(50)
                .HasColumnName("Food_ID");
            entity.Property(e => e.FoodName)
                .HasMaxLength(50)
                .HasColumnName("Food_Name");
            entity.Property(e => e.FoodPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Food_Price");
            entity.Property(e => e.FoodType)
                .HasMaxLength(50)
                .HasColumnName("Food_Type");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiId);

            entity.ToTable("Koi_Fish");

            entity.Property(e => e.KoiId)
                .ValueGeneratedNever()
                .HasColumnName("Koi_ID");
            entity.Property(e => e.KoiAge).HasColumnName("Koi_Age");
            entity.Property(e => e.KoiColor)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Koi_Color");
            entity.Property(e => e.KoiGen)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Koi_Gen");
            entity.Property(e => e.KoiName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Koi_Name");
            entity.Property(e => e.KoiPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Koi_Price");
            entity.Property(e => e.KoiRare)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Koi_Rare");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.PlayerId)
                .ValueGeneratedNever()
                .HasColumnName("Player_ID");
            entity.Property(e => e.Coin).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("User_Name");
        });

        modelBuilder.Entity<PlayerKoiFish>(entity =>
        {
            entity.HasKey(e => e.PlayerKoiFishId).HasName("PK__PlayerKo__AD6DBDA66988DF69");

            entity.ToTable("PlayerKoiFish");

            entity.Property(e => e.PlayerKoiFishId)
                .ValueGeneratedNever()
                .HasColumnName("PlayerKoiFishID");
            entity.Property(e => e.KoiId).HasColumnName("Koi_ID");
            entity.Property(e => e.PlayerId).HasColumnName("Player_ID");

            entity.HasOne(d => d.Koi).WithMany(p => p.PlayerKoiFishes)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__PlayerKoi__Koi_I__4AB81AF0");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.PondId).HasName("PK__Pond__1302698EDD5AFAC3");

            entity.ToTable("Pond");

            entity.Property(e => e.PondId)
                .ValueGeneratedNever()
                .HasColumnName("Pond_ID");
            entity.Property(e => e.PondName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("Pond_Name");
            entity.Property(e => e.PondPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Pond_Price");
        });

        modelBuilder.Entity<Trade>(entity =>
        {
            entity.HasKey(e => e.TradeId).HasName("PK__Trade__B379B34E010AB75B");

            entity.ToTable("Trade");

            entity.Property(e => e.TradeId)
                .ValueGeneratedNever()
                .HasColumnName("Trade_ID");
            entity.Property(e => e.BuyerId).HasColumnName("BuyerID");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.KoiId).HasColumnName("Koi_ID");
            entity.Property(e => e.SellerId).HasColumnName("SellerID");

            entity.HasOne(d => d.Buyer).WithMany(p => p.TradeBuyers)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__Trade__BuyerID__403A8C7D");

            entity.HasOne(d => d.Seller).WithMany(p => p.TradeSellers)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Trade__SellerID__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
