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

        public virtual DbSet<DetEgressUsuario> DetEgressUsuario { get; set; }
        public virtual DbSet<EgressUsuario> EgressUsuario { get; set; }
        public virtual DbSet<JwtEgress> JwtEgress { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var configuration = builder.Build();
                var PathConnectionString = configuration["ConnectionStrings:BloggingDatabase"];
                optionsBuilder.UseSqlServer(PathConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetEgressUsuario>(entity =>
            {
                entity.ToTable("Det_EgressUsuario");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.DetEgressUsuario)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Det_EgressUsuario_EgressUsuario");
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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JwtEgress>(entity =>
            {
                entity.ToTable("Jwt_Egress");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.JwtEgress)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jwt_Egress_EgressUsuario");
            });

            modelBuilder.Entity<Parametros>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
