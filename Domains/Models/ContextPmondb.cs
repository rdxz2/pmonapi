using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pmonapi.Domains.Models
{
    public partial class ContextPmondb : DbContext
    {
        public ContextPmondb()
        {
        }

        public ContextPmondb(DbContextOptions<ContextPmondb> options)
            : base(options)
        {
        }

        public virtual DbSet<m_icon> m_icon { get; set; }
        public virtual DbSet<m_menu> m_menu { get; set; }
        public virtual DbSet<m_menu_category> m_menu_category { get; set; }
        public virtual DbSet<m_user> m_user { get; set; }
        public virtual DbSet<m_user_detail> m_user_detail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Name=Pmondb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<m_icon>(entity =>
            {
                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<m_menu>(entity =>
            {
                entity.HasIndex(e => e.cb)
                    .HasName("fk_mmenu_muser_cb");

                entity.HasIndex(e => e.id_m_icon)
                    .HasName("fk_mmenu_micon");

                entity.HasIndex(e => e.id_m_menu_category)
                    .HasName("fk_mmenu_mmenucategory");

                entity.HasIndex(e => e.lb)
                    .HasName("fk_mmenu_muser_lb");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.active)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.cb).HasColumnType("int(11)");

                entity.Property(e => e.cd).HasColumnType("datetime");

                entity.Property(e => e.component)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.id_m_icon).HasColumnType("int(11)");

                entity.Property(e => e.id_m_menu_category).HasColumnType("int(11)");

                entity.Property(e => e.lb).HasColumnType("int(11)");

                entity.Property(e => e.ld).HasColumnType("datetime");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.order).HasColumnType("int(11)");

                entity.Property(e => e.path)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.cbNavigation)
                    .WithMany(p => p.m_menucbNavigation)
                    .HasForeignKey(d => d.cb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mmenu_muser_cb");

                entity.HasOne(d => d.id_m_iconNavigation)
                    .WithMany(p => p.m_menu)
                    .HasForeignKey(d => d.id_m_icon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mmenu_micon");

                entity.HasOne(d => d.id_m_menu_categoryNavigation)
                    .WithMany(p => p.m_menu)
                    .HasForeignKey(d => d.id_m_menu_category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mmenu_mmenucategory");

                entity.HasOne(d => d.lbNavigation)
                    .WithMany(p => p.m_menulbNavigation)
                    .HasForeignKey(d => d.lb)
                    .HasConstraintName("fk_mmenu_muser_lb");
            });

            modelBuilder.Entity<m_menu_category>(entity =>
            {
                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.active)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.cb).HasColumnType("int(11)");

                entity.Property(e => e.cd).HasColumnType("datetime");

                entity.Property(e => e.lb).HasColumnType("int(11)");

                entity.Property(e => e.ld).HasColumnType("datetime");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<m_user>(entity =>
            {
                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.active)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.cb).HasColumnType("int(11)");

                entity.Property(e => e.cd).HasColumnType("datetime");

                entity.Property(e => e.lb).HasColumnType("int(11)");

                entity.Property(e => e.ld).HasColumnType("datetime");

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.username)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<m_user_detail>(entity =>
            {
                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ext)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.idNavigation)
                    .WithOne(p => p.m_user_detail)
                    .HasForeignKey<m_user_detail>(d => d.id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_muserdetail_muser");
            });
        }
    }
}
