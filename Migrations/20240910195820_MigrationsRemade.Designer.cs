﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StorageLogistic.Models;

#nullable disable

namespace StorageLogistic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240910195820_MigrationsRemade")]
    partial class MigrationsRemade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("StorageLogistic.Models.ProductHistory", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChangedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NewAmount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreviousAmount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HistoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductHistories");
                });

            modelBuilder.Entity("StorageLogistic.Models.Products", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastSoldDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("SoldAmount")
                        .HasColumnType("INTEGER");

                    b.HasKey("RequestId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StorageLogistic.Models.ProductHistory", b =>
                {
                    b.HasOne("StorageLogistic.Models.Products", "Product")
                        .WithMany("ProductHistories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StorageLogistic.Models.Products", b =>
                {
                    b.Navigation("ProductHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
