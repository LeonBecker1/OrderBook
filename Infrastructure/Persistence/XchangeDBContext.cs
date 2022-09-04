using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OrderBook.Infrastructure.Persistence.Models;

namespace OrderBook.Infrastructure.Persistence
{
    public partial class XchangeDBContext : DbContext
    {
        public XchangeDBContext()
        {
        }

        public XchangeDBContext(DbContextOptions<XchangeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Portfolio> Portfolios { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=LEON-PC\\SQLEXPRESS;Initial Catalog=XchangeDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.IssuerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Issuer)
                    .HasConstraintName("FK__Orders__Issuer__619B8048");

                entity.HasOne(d => d.UnderlyingNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Underlying)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Underlyi__60A75C0F");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.HasOne(d => d.StockNavigation)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.Stock)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Portfolio__Stock__656C112C");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Portfolios)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Portfolio__User___6477ECF3");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
