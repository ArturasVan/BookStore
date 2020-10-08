using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;


namespace BookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderHasProduct>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.OrderHasProduct)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderHasP__RoleI__32E0915F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderHasProduct)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderHasP__UserI__31EC6D26");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__2C3393D0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Autor)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Info)
                    .HasColumnType("text");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductHasCategory>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductHasCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductHa__Categ__45F365D3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductHasCategory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductHa__Produ__44FF419A");
            });

            modelBuilder.Entity<AppUserRoles>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserHasRoles>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserHasRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserHasRo__RoleI__286302EC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserHasRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserHasRo__UserI__276EDEB3");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.BillingAddress)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCity)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryCity)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<OrderHasProduct> OrderHasProduct { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductHasCategory> ProductHasCategory { get; set; }
        public virtual DbSet<AppUserRoles> AppUserRoles { get; set; }
        public virtual DbSet<UserHasRoles> UserHasRoles { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
