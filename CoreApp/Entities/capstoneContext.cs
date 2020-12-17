using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreApp.Entities
{
    public partial class capstoneContext : DbContext
    {
        public capstoneContext()
        {
        }

        public capstoneContext(DbContextOptions<capstoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Stocks> Stocks { get; set; }
        public virtual DbSet<StocksHistory> StocksHistory { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=PELAYO-FAMILY\\SQLEXPRESS2017;Database=capstone;user id=capstoneuser1;password=capstoneuser1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.Store)
                    .HasConstraintName("FK_Category_Store");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Category_User");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.DirectoryPath)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.QuantityPerUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Category");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Store)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Store");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Products_User");
            });

            modelBuilder.Entity<Stocks>(entity =>
            {
                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stocks_Products");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.Store)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stocks_Store");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Stocks_User");
            });

            modelBuilder.Entity<StocksHistory>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.HasOne(d => d.StockNavigation)
                    .WithMany(p => p.StocksHistory)
                    .HasForeignKey(d => d.Stock)
                    .HasConstraintName("FK_StocksHistory_Stocks");

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.StocksHistory)
                    .HasForeignKey(d => d.Store)
                    .HasConstraintName("FK_StocksHistory_Store");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StocksHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_StocksHistory_User");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Store_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
