﻿// <auto-generated />
using System;
using CoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreApp.Migrations
{
    [DbContext(typeof(CoreContext))]
    partial class CoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreApp.Models.Category", b =>
                {
                    b.Property<int>("CatagoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("CatagoryId");

                    b.HasIndex("StoreId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CoreApp.Models.Product", b =>
                {
                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Description")
                        .HasColumnType("varbinary(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("QuantityPerUnit")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CoreApp.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.HasKey("StoreId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("CoreApp.Models.Category", b =>
                {
                    b.HasOne("CoreApp.Models.Store", "Store")
                        .WithMany("Category")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK_StoreId_Category");
                });

            modelBuilder.Entity("CoreApp.Models.Product", b =>
                {
                    b.HasOne("CoreApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Product_CategoryID");
                });
#pragma warning restore 612, 618
        }
    }
}
