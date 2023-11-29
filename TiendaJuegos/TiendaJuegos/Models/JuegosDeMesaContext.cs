using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TiendaJuegos.Models;

public partial class JuegosDeMesaContext : DbContext
{
    public JuegosDeMesaContext()
    {
    }

    public JuegosDeMesaContext(DbContextOptions<JuegosDeMesaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    public virtual DbSet<Trabajadore> Trabajadores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //=> optionsBuilder.UseSqlServer("Server=DESKTOP-1OD1BA3\\SQLEXPRESS;Database=JuegosDeMesa;Integrated Security=True; TrustServerCertificate=True");   
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC0725586B02");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.TipoProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.TipoProductoId)
                .HasConstraintName("FK__Productos__TipoP__4316F928");
        });

        modelBuilder.Entity<TipoProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoProd__3214EC07851A9731");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trabajadore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trabajad__3214EC07CB0930EC");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumeroCelular)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Rut)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__Ventas__0A5CDB5C65CB046B");

            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductosVendidos).HasColumnType("text");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Venta)
                .HasForeignKey(d => d.VendedorId)
                .HasConstraintName("FK__Ventas__Vendedor__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
