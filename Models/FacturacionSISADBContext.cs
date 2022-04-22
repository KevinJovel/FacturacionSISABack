using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FacturacionSISA.Models
{
    public partial class FacturacionSISADBContext : DbContext
    {
        public FacturacionSISADBContext()
        {
        }

        public FacturacionSISADBContext(DbContextOptions<FacturacionSISADBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TDetOrdenCompra> TDetOrdenCompras { get; set; }
        public virtual DbSet<TOrdenCompra> TOrdenCompras { get; set; }
        public virtual DbSet<TProducto> TProductos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6301TK6\\SQLEXPRESS;Initial Catalog=FacturacionSISADB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TDetOrdenCompra>(entity =>
            {
                entity.HasKey(e => e.DetOrdenId)
                    .HasName("PK__T_DET_OR__BF5B2F7472BC97B1");

                entity.ToTable("T_DET_ORDEN_COMPRA");

                entity.Property(e => e.DetOrdenId).HasColumnName("DetOrdenID");

                entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.TDetOrdenCompras)
                    .HasForeignKey(d => d.OrdenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__T_DET_ORD__Orden__4F7CD00D");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.TDetOrdenCompras)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__T_DET_ORD__Produ__4E88ABD4");
            });

            modelBuilder.Entity<TOrdenCompra>(entity =>
            {
                entity.HasKey(e => e.OrdenCompraId)
                    .HasName("PK__T_ORDEN___0B556E160120D93C");

                entity.ToTable("T_ORDEN_COMPRA");

                entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<TProducto>(entity =>
            {
                entity.HasKey(e => e.ProductoId)
                    .HasName("PK__T_PRODUC__A430AE836BAC5DE4");

                entity.ToTable("T_PRODUCTO");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
