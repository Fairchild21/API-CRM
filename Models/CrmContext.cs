using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRM.Models;

public partial class CrmContext : DbContext
{
    public CrmContext()
    {
    }

    public CrmContext(DbContextOptions<CrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-APU3DEDU;Database=Crm;Trusted_Connection=True;trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83F265B716F");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.State)
                .HasDefaultValueSql("((1))")
                .HasColumnName("state");
            entity.Property(e => e.TotalCaHt).HasColumnName("totalCaHt");
            entity.Property(e => e.Tva)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tva");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3213E83F75B44B0E");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Client)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("client");
            entity.Property(e => e.Comment)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.NbJours)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("nbJours");
            entity.Property(e => e.State)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.TjmHt)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tjmHT");
            entity.Property(e => e.Tva)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tva");
            entity.Property(e => e.TypePresta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typePResta");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__id_clien__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F0678063A");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConfirmedPassword)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("confirmedPassword");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Grants)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("grants");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
