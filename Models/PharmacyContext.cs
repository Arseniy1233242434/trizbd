using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Models;

public partial class PharmacyContext : DbContext
{
    public PharmacyContext()
    {
    }

    public PharmacyContext(DbContextOptions<PharmacyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arrival> Arrivals { get; set; }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIN-R0FOFS4V1GK\\FUTFGT7U;Database=Pharmacy;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arrival>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.MedicineId).HasColumnName("medicine_id");
            entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.PricePackage)
                .HasColumnType("money")
                .HasColumnName("pricePackage");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Arrivals)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK_Arrivals_Medicine");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Arrivals)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Arrivals_Suppliers");
        });

        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.ToTable("Medicine");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategotyId).HasColumnName("categoty_id");
            entity.Property(e => e.ConditionId).HasColumnName("condition_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Dosage)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("dosage");
            entity.Property(e => e.ExpirationPeriod).HasColumnName("expirationPeriod");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Prescription).HasColumnName("prescription");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.UnitinId).HasColumnName("unitin_id");

            entity.HasOne(d => d.Categoty).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.CategotyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Categories");

            entity.HasOne(d => d.Condition).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.ConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Conditions");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Manufacturers");

            entity.HasOne(d => d.Type).WithMany(p => p.Medicines)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Types");

            entity.HasOne(d => d.Unit).WithMany(p => p.MedicineUnits)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Units");

            entity.HasOne(d => d.Unitin).WithMany(p => p.MedicineUnitins)
                .HasForeignKey(d => d.UnitinId)
                .HasConstraintName("FK_Medicine_Units1");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArrivalId).HasColumnName("arrival_id");
            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");
            entity.Property(e => e.Payment).HasColumnName("payment");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.SellerId).HasColumnName("seller_id");

            entity.HasOne(d => d.Arrival).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ArrivalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Arrivals");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_Sales_Buyers");

            entity.HasOne(d => d.Seller).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Sellers");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_suppliers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactPerson).HasColumnName("contactPerson");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
