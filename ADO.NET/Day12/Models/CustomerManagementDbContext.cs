using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Day12.Models;

public partial class CustomerManagementDbContext : DbContext
{
    public CustomerManagementDbContext()
    {
    }

    public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactPerson> ContactPeople { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<CustomerAudit> CustomerAudits { get; set; }

    public virtual DbSet<CustomerInteraction> CustomerInteractions { get; set; }

    public virtual DbSet<Segment> Segments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CustomerManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactPerson>(entity =>
        {
            entity.HasKey(e => e.ContactPersonId).HasName("PK__ContactP__97C702BE06F250E3");

            entity.ToTable("ContactPerson");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.ContactPeople)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__ContactPe__Custo__3E52440B");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8841A583B");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Segment).WithMany(p => p.Customers)
                .HasForeignKey(d => d.SegmentId)
                .HasConstraintName("FK__Customer__Segmen__3A81B327");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Customer__091C2AFBB318520B");

            entity.ToTable("CustomerAddress");

            entity.Property(e => e.AddressType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CustomerA__Custo__4222D4EF");
        });

        modelBuilder.Entity<CustomerAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Customer__A17F239807439E22");

            entity.ToTable("CustomerAudit");

            entity.Property(e => e.ChangedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ChangedField)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NewValue)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OldValue)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerInteraction>(entity =>
        {
            entity.HasKey(e => e.InteractionId).HasName("PK__Customer__922C049655D054F7");

            entity.ToTable("CustomerInteraction");

            entity.Property(e => e.Details).IsUnicode(false);
            entity.Property(e => e.InteractionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InteractionType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerInteractions)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CustomerI__Custo__48CFD27E");
        });

        modelBuilder.Entity<Segment>(entity =>
        {
            entity.HasKey(e => e.SegmentId).HasName("PK__Segment__C680677B3DDF07AC");

            entity.ToTable("Segment");

            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SegmentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
