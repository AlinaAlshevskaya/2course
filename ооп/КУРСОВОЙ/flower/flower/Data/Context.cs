using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using flower.Models;

namespace flower.Data;

public partial class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory);

            entity.Property(e => e.IdCategory)
                .ValueGeneratedNever()
                .HasColumnName("id_category");
            entity.Property(e => e.Category1)
                .HasMaxLength(100)
                .HasColumnName("category");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.IdColorName);

            entity.Property(e => e.IdColorName)
                .ValueGeneratedNever()
                .HasColumnName("id_color_name");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .HasColumnName("color_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK_Orders_");

            entity.Property(e => e.IdOrder)
                .ValueGeneratedNever()
                .HasColumnName("id_order");
            entity.Property(e => e.DeliveryAdres)
                .HasMaxLength(50)
                .HasColumnName("delivery_adres");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.DeliveryTime)
                .HasMaxLength(10)
                .HasColumnName("delivery_time");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(50)
                .HasColumnName("order_status");
            entity.Property(e => e.ReciverFio)
                .HasMaxLength(50)
                .HasColumnName("reciver_FIO");
            entity.Property(e => e.ReciverPhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("reciver_phone_number");
            entity.Property(e => e.TatalPrice).HasColumnName("tatal_price");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders__Users");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Order_details");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");

            entity.HasOne(d => d.IdOrderNavigation).WithMany()
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_details_Orders_");

            entity.HasOne(d => d.IdProductNavigation).WithMany()
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_details_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.Property(e => e.IdProduct)
                .ValueGeneratedNever()
                .HasColumnName("id_product");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Discription).HasColumnName("discription");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdColorName).HasColumnName("id_color_name");
            entity.Property(e => e.IsAvailable)
                .HasComputedColumnSql("(case when [Amount]>(0) then (1) else (0) end)", true)
                .HasColumnName("isAvailable");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.IdColorNameNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdColorName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Colors");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview);

            entity.Property(e => e.IdReview)
                .ValueGeneratedNever()
                .HasColumnName("id_review");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Rate).HasColumnName("rate");
            entity.Property(e => e.Text).HasColumnName("text");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Orders_");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("id_user");
            entity.Property(e => e.Adres)
                .HasMaxLength(100)
                .HasColumnName("adres");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(300)
                .HasColumnName("image_path");
            entity.Property(e => e.IsAdmin).HasColumnName("is_Admin");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
