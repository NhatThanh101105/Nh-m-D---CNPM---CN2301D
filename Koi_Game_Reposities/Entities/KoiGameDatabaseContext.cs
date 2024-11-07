using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Koi_Game_Reposities.Entities;

public partial class KoiGameDatabaseContext : DbContext
{
    public KoiGameDatabaseContext()
    {
    }

    public KoiGameDatabaseContext(DbContextOptions<KoiGameDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerKoi> PlayerKoi { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    public virtual DbSet<Upgrade> Upgrades { get; set; }

    public virtual DbSet<PondKoi> PondKois { get; set; }
    public virtual DbSet<PlayerPond> PlayerPonds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("Server=HAI2\\SQLEXPRESS; DataBase=Koi_Game_Database;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__Food__856DB3EB5A5EED96");

            entity.ToTable("Food");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__F5FDE6B38ACEE2A8");

            entity.ToTable("Inventory");

            entity.Property(e => e.ItemType).HasMaxLength(20);

            entity.HasOne(d => d.Player).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__Inventory__Playe__4BAC3F29");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__KoiFish__E03435985BC48358");

            entity.ToTable("KoiFish");

            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.KoiName).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Rare).HasMaxLength(20);
            entity.Property(e => e.ImageURL).HasColumnType("nvarchar(max)").IsRequired(false);


        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Player__4A4E74C82A608C7A");

            entity.ToTable("Player");

            entity.HasIndex(e => e.UserName, "UQ__Player__C9F28456415A05F0").IsUnique();

            entity.Property(e => e.Coin).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.IsNewPlayer) // Đảm bảo rằng IsNewPlayer đã được thêm vào lớp Player
     .IsRequired();
        });

        modelBuilder.Entity<PlayerKoi>(entity =>
        {
            entity.HasKey(e => e.PlayerKoiId).HasName("PK__PlayerKo__C89132A3A6886891");

            entity.ToTable("PlayerKoi");

            entity.HasOne(d => d.Koi).WithMany(p => p.PlayerKois)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__PlayerKoi__KoiId__3D5E1FD2");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerKois)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__PlayerKoi__Playe__3C69FB99");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.PondId).HasName("PK__Pond__D18BF834C18AC6C5");

            entity.ToTable("Pond");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size).HasMaxLength(20);
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.ShopId).HasName("PK__Shop__67C557C9004510DC");

            entity.ToTable("Shop");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ItemName).HasMaxLength(50);
            entity.Property(e => e.ItemType).HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Trade>(entity =>
        {
            entity.HasKey(e => e.TradeId).HasName("PK__Trade__3028BB5BB03C58D0");

            entity.ToTable("Trade");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Buyer).WithMany(p => p.TradeBuyers)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__Trade__BuyerId__47DBAE45");

            entity.HasOne(d => d.Koi).WithMany(p => p.Trades)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__Trade__KoiId__48CFD27E");

            entity.HasOne(d => d.Seller).WithMany(p => p.TradeSellers)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Trade__SellerId__46E78A0C");
        });

        modelBuilder.Entity<Upgrade>(entity =>
        {
            entity.HasKey(e => e.UpgradeId).HasName("PK__Upgrades__CA188BE50EF5E1D5");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpgradeName).HasMaxLength(50);
        });
        /*
                modelBuilder.Entity<PondKoi>(entity =>
                {
                    entity.HasKey(e => e.PondKoiId).HasName("PK__PondKoi__X"); // Thay 'X' bằng ID khóa chính thực tế.

                    entity.ToTable("PondKoi");

                    entity.HasOne(d => d.PlayerPond) // Ràng buộc tới bảng Pond
                        .WithMany(p => p.PondKois) // Có thể có nhiều cá trong một hồ
                        .HasForeignKey(d => d.PondId) // Chỉ định khóa ngoại
                        .OnDelete(DeleteBehavior.Cascade); // Xóa cả cá trong hồ khi hồ bị xóa

                    entity.HasOne(d => d.PlayerKoi) // Ràng buộc tới bảng PlayerKoi
                        .WithMany(p => p.PondKois) // Có thể có nhiều cá trong một hồ
                        .HasForeignKey(d => d.PlayerKoiId) // Chỉ định khóa ngoại
                        .OnDelete(DeleteBehavior.Cascade); // Xóa cá khi nó bị xóa khỏi hồ
                });*/

        modelBuilder.Entity<PondKoi>(entity =>
        {
            entity.HasKey(e => e.PondKoiId).HasName("PK_PondKoi");

            entity.ToTable("PondKoi");

            entity.HasOne(d => d.PlayerPond)
                .WithMany(p => p.PondKois)
                .HasForeignKey(d => d.PlayerPondId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PondKoi_PlayerPond");

            entity.HasOne(d => d.PlayerKoi)
                .WithMany(p => p.PondKois)
                .HasForeignKey(d => d.PlayerKoiId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PondKoi_PlayerKoi");
        });

        modelBuilder.Entity<PlayerPond>(entity =>
        {
            entity.HasKey(e => e.PlayerPondId).HasName("PK_PlayerPond");

            entity.ToTable("PlayerPond");

            entity.HasOne(d => d.Player)
                .WithMany(p => p.PlayerPonds)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Pond)
                .WithMany(p => p.PlayerPonds)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
