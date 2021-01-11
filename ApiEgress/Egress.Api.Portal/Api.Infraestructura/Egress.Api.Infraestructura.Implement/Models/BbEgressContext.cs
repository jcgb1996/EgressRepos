using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Egress.Api.Infraestructura.Implement.Models
{
    public partial class BbEgressContext : DbContext
    {
        public BbEgressContext()
        {
        }

        public BbEgressContext(DbContextOptions<BbEgressContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EgressDetUsuario> EgressDetUsuario { get; set; }
        public virtual DbSet<EgressUsuario> EgressUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                   #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-3REL3TOL\\SQLEXPRESS;Database=BbEgress;User ID=sa;Password=Egress.c0m.10.2021;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EgressDetUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Passwors)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EgressDetUsuario_EgressUsuario");
            });

            modelBuilder.Entity<EgressUsuario>(entity =>
            {
                entity.HasKey(e => e.Usuario)
                    .HasName("PK_Usuario.EgressUsuario");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
