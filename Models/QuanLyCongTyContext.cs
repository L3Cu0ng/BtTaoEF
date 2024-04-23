using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace btEntityFramework.Models;

public partial class QuanLyCongTyContext : DbContext
{
    public QuanLyCongTyContext()
    {
    }

    public QuanLyCongTyContext(DbContextOptions<QuanLyCongTyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Congty> Congties { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3H69VAF;Initial Catalog=QuanLyCongTy;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Congty>(entity =>
        {
            entity.HasKey(e => e.IdCongTy).HasName("PK__Congty__1BE5BDC3DA3C05BD");

            entity.ToTable("Congty");

            entity.Property(e => e.IdCongTy)
                .ValueGeneratedNever()
                .HasColumnName("ID_CongTy");
            entity.Property(e => e.DiaChiCongTy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenCongTy)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Manv).HasName("PK__NhanVien__603F5114853684A4");

            entity.ToTable("NhanVien");

            entity.Property(e => e.Manv)
                .ValueGeneratedNever()
                .HasColumnName("MANV");
            entity.Property(e => e.Diachi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Hoten)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HOTEN");
            entity.Property(e => e.Luong).HasColumnName("LUONG");
            entity.Property(e => e.Mapb).HasColumnName("MAPB");
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");

            entity.HasOne(d => d.MapbNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.Mapb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__MAPB__403A8C7D");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.Mapb).HasName("PK__PhongBan__603F61C23276D316");

            entity.ToTable("PhongBan");

            entity.Property(e => e.Mapb)
                .ValueGeneratedNever()
                .HasColumnName("MAPB");
            entity.Property(e => e.IdCongTy).HasColumnName("ID_CongTy");
            entity.Property(e => e.Tenpb)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TENPB");

            entity.HasOne(d => d.IdCongTyNavigation).WithMany(p => p.PhongBans)
                .HasForeignKey(d => d.IdCongTy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhongBan__ID_Con__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
