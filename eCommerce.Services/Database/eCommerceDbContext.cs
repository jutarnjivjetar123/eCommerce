using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace eCommerce.Services.Database;

public partial class eCommerceContext : DbContext
{
    public eCommerceContext()
    {
    }

    public eCommerceContext(DbContextOptions<eCommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Suppliers> Suppliers { get; set; }
    public virtual DbSet<SalesItems> SalesItems { get; set; }
    public virtual DbSet<Sales> Sales { get; set; }
    public virtual DbSet<UnitOfMeasures> UnitOfMeasures { get; set; }
    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<UserRoles> UserRoles { get; set; }
    public virtual DbSet<Customers> Customers { get; set; }
    public virtual DbSet<OrderItems> OrderItems { get; set; }
    public virtual DbSet<Orders> Orders { get; set; }
    public virtual DbSet<Reviews> Reviews { get; set; }
    public virtual DbSet<Products> Products { get; set; }
    public virtual DbSet<Warehouses> Warehouses { get; set; }
    public virtual DbSet<PurchaseItems> PurchaseItems { get; set; }
    public virtual DbSet<PurchaseEntries> PurchaseEntries { get; set; }
    public virtual DbSet<Roles> Roles { get; set; }
    public virtual DbSet<ProductCategories> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AI");

        modelBuilder.Entity<Suppliers>(entity =>
        {
            entity.HasKey(e => e.SupplierId);
            entity.ToTable("Suppliers");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(25);
            entity.Property(e => e.Fax).HasMaxLength(25);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.Website).HasMaxLength(100);
            entity.Property(e => e.BankAccounts).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(500);
        });

        modelBuilder.Entity<SalesItems>(entity =>
        {
            entity.HasKey(e => e.SalesItemId);
            entity.ToTable("SalesItems");

            entity.Property(e => e.SalesItemId).HasColumnName("SalesItemID");
            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(5,2)");

            entity.HasOne(d => d.Sale).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesItems_Sales");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesItems_Products");
        });

        modelBuilder.Entity<Sales>(entity =>
        {
            entity.HasKey(e => e.SaleId);
            entity.ToTable("Sales");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.AmountWithoutVAT).HasColumnType("decimal(18,2)");
            entity.Property(e => e.AmountWithVAT).HasColumnType("decimal(18,2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.User).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Users");

            entity.HasOne(d => d.Order).WithMany(p => p.Sales)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Sales_Orders");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Sales)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Warehouses");
        });

        modelBuilder.Entity<UnitOfMeasures>(entity =>
        {
            entity.HasKey(e => e.UnitOfMeasureId);
            entity.ToTable("UnitOfMeasures");

            entity.Property(e => e.UnitOfMeasureId).HasColumnName("UnitOfMeasureID");
            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.ToTable("Users");

            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Username).IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.PasswordSalt).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status).IsRequired().HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<UserRoles>(entity =>
        {
            entity.HasKey(e => e.UserRoleId);
            entity.ToTable("UserRoles");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");
        });

        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(e => e.CustomerId);
            entity.ToTable("Customers");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.PasswordSalt).HasMaxLength(50);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderItems>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);
            entity.ToTable("OrderItems");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Products");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.ToTable("Orders");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderNumber).HasMaxLength(20);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<Reviews>(entity =>
        {
            entity.HasKey(e => e.ReviewId);
            entity.ToTable("Reviews");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Rating);
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Customers");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Products");
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.ToTable("Products");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.UnitOfMeasureId).HasColumnName("UnitOfMeasureID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Status).IsRequired().HasDefaultValueSql("((1))");
            entity.Property(e => e.Image);
            entity.Property(e => e.Thumbnail);

            entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_UnitOfMeasures");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductCategories");
        });

        modelBuilder.Entity<Warehouses>(entity =>
        {
            entity.HasKey(e => e.WarehouseId);
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<PurchaseItems>(entity =>
        {
            entity.HasKey(e => e.PurchaseItemId);
            entity.ToTable("PurchaseItems");

            entity.Property(e => e.PurchaseItemId).HasColumnName("PurchaseItemID");
            entity.Property(e => e.PurchaseEntryId).HasColumnName("PurchaseEntryID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseItems_Products");

            entity.HasOne(d => d.PurchaseEntry).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.PurchaseEntryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseItems_PurchaseEntries");
        });

        modelBuilder.Entity<PurchaseEntries>(entity =>
        {
            entity.HasKey(e => e.PurchaseEntryId);
            entity.ToTable("PurchaseEntries");

            entity.Property(e => e.PurchaseEntryId).HasColumnName("PurchaseEntryID");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(20);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.VAT).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseEntries)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseEntries_Suppliers");

            entity.HasOne(d => d.User).WithMany(p => p.PurchaseEntries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseEntries_Users");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.PurchaseEntries)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseEntries_Warehouses");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RoleId);
            entity.ToTable("Roles");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(200);
        });

        modelBuilder.Entity<ProductCategories>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}