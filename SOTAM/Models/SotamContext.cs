using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SOTAM.Models;

public partial class SotamContext : DbContext
{
    public SotamContext()
    {
    }

    public SotamContext(DbContextOptions<SotamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<QueueList> QueueLists { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=RimBo\\SQLEXPRESS03;Database=SOTAM;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E89C6F93B4");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Username, "UQ__Admin__536C85E434607868").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<QueueList>(entity =>
        {
            entity.HasKey(e => e.QueueId).HasName("PK__QueueLis__8324E8F5BAE102C6");

            entity.ToTable("QueueList");

            entity.Property(e => e.QueueId).HasColumnName("QueueID");
            entity.Property(e => e.Customer).HasMaxLength(100);
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Table).WithMany(p => p.QueueLists)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__QueueList__Table__3F466844");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Tables__7D5F018E1E0BEF02");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Customer).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TableName).HasMaxLength(50);
            entity.Property(e => e.TimeEnd).HasColumnType("datetime");
            entity.Property(e => e.TimeLeft).HasMaxLength(20);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B5E7801C6");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SessionId)
                .HasMaxLength(20)
                .HasColumnName("SessionID");
            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Table).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__Transacti__Table__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
