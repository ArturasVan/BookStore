using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Microsoft.AspNetCore.Http;

namespace BookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
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

            // modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Essay" },
            //                             new Category { Id = 2, Name = "Novel" });


            modelBuilder.Entity<OrderHasProduct>().HasKey(sc => new { sc.OrderId, sc.ProductId });

            modelBuilder.Entity<OrderHasProduct>()
            .HasOne<Orders>(sc => sc.Orders)
            .WithMany(s => s.OrderHasProducts)
            .HasForeignKey(sc => sc.OrderId);


            modelBuilder.Entity<OrderHasProduct>()
                .HasOne(sc => sc.Product)
                .WithMany(s => s.OrderHasProducts)
                .HasForeignKey(sc => sc.ProductId);


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

            modelBuilder.Entity<ProductPicture>()
                        .HasOne(s => s.Product)
                        .WithMany(g => g.Pictures)
                        .HasForeignKey(s => s.ProductId);


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


            });

        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<OrderHasProduct> OrderHasProduct { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductHasCategory> ProductHasCategory { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ProductPicture> ProductPictures { get; set; }
        
    }
}
