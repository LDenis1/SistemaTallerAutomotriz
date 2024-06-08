using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dastone.Entities;

public partial class PruebaContexto : DbContext
{
    public PruebaContexto()
    {
    }

    public PruebaContexto(DbContextOptions<PruebaContexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<OrdenTrabajo> OrdenTrabajos { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<RepuestoUsado> RepuestoUsados { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserxRol> UserxRols { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__Cita__F0E2D9D2C1792184");

            entity.Property(e => e.Descripcion).HasMaxLength(600);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Notas).HasMaxLength(200);
            entity.Property(e => e.TipoServicio).HasMaxLength(500);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD08702CCAA9A");

            entity.ToTable("Cliente");

            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Notas).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<OrdenTrabajo>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__OrdenTra__C088A50404E6A040");

            entity.ToTable("OrdenTrabajo");

            entity.Property(e => e.DetalleOrden).HasMaxLength(300);
            entity.Property(e => e.Estado).HasMaxLength(60);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
            entity.Property(e => e.Notas).HasMaxLength(200);
            entity.Property(e => e.Observaciones).HasMaxLength(1000);
            entity.Property(e => e.Placa).HasMaxLength(200);
            entity.Property(e => e.TipoTrabajo).HasMaxLength(300);

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenTrabajos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__OrdenTrab__Clien__18B6AB08");

            entity.HasOne(d => d.PlacaNavigation).WithMany(p => p.OrdenTrabajos)
                .HasForeignKey(d => d.Placa)
                .HasConstraintName("FK__OrdenTrab__Placa__19AACF41");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.HasKey(e => e.RepuestoId).HasName("PK__Repuesto__75B30694CA1DB9F3");

            entity.ToTable("Repuesto");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Notas).HasMaxLength(500);
            entity.Property(e => e.NumeroParte).HasMaxLength(100);
            entity.Property(e => e.Proveedor).HasMaxLength(60);
        });

        modelBuilder.Entity<RepuestoUsado>(entity =>
        {
            entity.HasKey(e => e.RepuestoUsadoId).HasName("PK__Repuesto__28EB0D90515DECCF");

            entity.Property(e => e.Descripcion).HasMaxLength(600);

            entity.HasOne(d => d.Orden).WithMany(p => p.RepuestoUsados)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("FK__RepuestoU__Orden__1E6F845E");

            entity.HasOne(d => d.Repuesto).WithMany(p => p.RepuestoUsados)
                .HasForeignKey(d => d.RepuestoId)
                .HasConstraintName("FK__RepuestoU__Repue__1F63A897");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F7646002266");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Accesso).HasColumnName("accesso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F5B61594B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<UserxRol>(entity =>
        {
            entity.HasKey(e => e.IdUsersxRol).HasName("PK__UserxRol__5AC99FB4F83BCA3B");

            entity.ToTable("UserxRol");

            entity.Property(e => e.IdUsersxRol).HasColumnName("idUsersxRol");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserxRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__UserxRol__idRol__3D5E1FD2");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserxRols)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__UserxRol__idUser__3C69FB99");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Placa).HasName("PK__Vehiculo__8310F99C59EE1B6C");

            entity.ToTable("Vehiculo");

            entity.Property(e => e.Placa).HasMaxLength(200);
            entity.Property(e => e.Color).HasMaxLength(40);
            entity.Property(e => e.Kilometraje).HasMaxLength(500);
            entity.Property(e => e.Marca).HasMaxLength(200);
            entity.Property(e => e.Modelo).HasMaxLength(100);
            entity.Property(e => e.Notas).HasMaxLength(300);
            entity.Property(e => e.VehiculoId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Vehiculo__Client__13F1F5EB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
