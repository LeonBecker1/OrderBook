﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderBook.Infrastructure.Persistence;

#nullable disable

namespace OrderBook.Infrastructure.Migrations
{
    [DbContext(typeof(OrderBookDBContext))]
    [Migration("20220906164903_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.OrderModel", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Order_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<bool>("IsBuyOrder")
                        .HasColumnType("BIT")
                        .HasColumnName("Is_Buy_Order");

                    b.Property<int>("IssuerUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("Price");

                    b.Property<int>("UnderlyingStockId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("IssuerUserId");

                    b.HasIndex("UnderlyingStockId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.PortfolioModel", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Portfolio_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortfolioId"), 1L, 1);

                    b.HasKey("PortfolioId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.PositionModel", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Position_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"), 1L, 1);

                    b.Property<int?>("PortfolioModelPortfolioId")
                        .HasColumnType("int");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("Quantity");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("PositionId");

                    b.HasIndex("PortfolioModelPortfolioId");

                    b.HasIndex("StockId");

                    b.ToTable("PositionModel");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.SaleModel", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Sale_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"), 1L, 1);

                    b.Property<int>("BuyerUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("Datetime")
                        .HasColumnName("Execution_Time");

                    b.Property<int>("SellerUserId")
                        .HasColumnType("int");

                    b.Property<int>("UnderlyingStockId")
                        .HasColumnType("int");

                    b.HasKey("SaleId");

                    b.HasIndex("BuyerUserId");

                    b.HasIndex("SellerUserId");

                    b.HasIndex("UnderlyingStockId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.StockModel", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Stock_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"), 1L, 1);

                    b.Property<string>("Abreviation")
                        .IsRequired()
                        .HasColumnType("Varchar(8)")
                        .HasColumnName("Abreviation");

                    b.HasKey("StockId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasColumnType("Decimal(6,2)")
                        .HasColumnName("Balance");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("Binary(64)")
                        .HasColumnName("Password");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("Varchar(32)")
                        .HasColumnName("User_Name");

                    b.HasKey("UserId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.OrderModel", b =>
                {
                    b.HasOne("OrderBook.Infrastructure.Persistence.Models.UserModel", "Issuer")
                        .WithMany("Orders")
                        .HasForeignKey("IssuerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderBook.Infrastructure.Persistence.Models.StockModel", "Underlying")
                        .WithMany("Orders")
                        .HasForeignKey("UnderlyingStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issuer");

                    b.Navigation("Underlying");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.PositionModel", b =>
                {
                    b.HasOne("OrderBook.Infrastructure.Persistence.Models.PortfolioModel", null)
                        .WithMany("Positions")
                        .HasForeignKey("PortfolioModelPortfolioId");

                    b.HasOne("OrderBook.Infrastructure.Persistence.Models.StockModel", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.SaleModel", b =>
                {
                    b.HasOne("OrderBook.Infrastructure.Persistence.Models.UserModel", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderBook.Infrastructure.Persistence.Models.UserModel", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderBook.Infrastructure.Persistence.Models.StockModel", "Underlying")
                        .WithMany()
                        .HasForeignKey("UnderlyingStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Seller");

                    b.Navigation("Underlying");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.UserModel", b =>
                {
                    b.HasOne("OrderBook.Infrastructure.Persistence.Models.PortfolioModel", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.PortfolioModel", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.StockModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OrderBook.Infrastructure.Persistence.Models.UserModel", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}