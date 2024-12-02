﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P_SGI_BE.Models;

#nullable disable

namespace P_SGI_BE.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("P_SGI_BE.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Costos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("NumFactura")
                        .HasColumnType("int");

                    b.Property<double>("valorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Costos");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdPropietario");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Medidas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medidas");
                });

            modelBuilder.Entity("P_SGI_BE.Models.MetodoPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.ToTable("MetodoPago");
                });

            modelBuilder.Entity("P_SGI_BE.Models.MovimientosInventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("NumFactura")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdPropietario");

                    b.HasIndex("IdUsuario");

                    b.ToTable("MovimientosInventarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.MovimientosVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<Guid>("IdServicio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<string>("NumFactura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.HasIndex("IdServicio");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdVenta");

                    b.ToTable("MovimientosVentas");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdMedida")
                        .HasColumnType("int");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoProducto")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdMedida");

                    b.HasIndex("IdPropietario");

                    b.HasIndex("IdTipoProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Propietarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Documento")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Propietarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Proveedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Recetas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<Guid>("IdServicio")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdPropietario");

                    b.HasIndex("IdServicio");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Servicios", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.TipoProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.ToTable("TipoProducto");
                });

            modelBuilder.Entity("P_SGI_BE.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Documento")
                        .HasColumnType("int");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Ventas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FechaCreacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdMetodoPago")
                        .HasColumnType("int");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.Property<string>("NumFactura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdMetodoPago");

                    b.HasIndex("IdPropietario");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Clientes", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Costos", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietarios");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Inventario", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Proveedores", "Proveedores")
                        .WithMany()
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Productos");

                    b.Navigation("Propietarios");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("P_SGI_BE.Models.MetodoPago", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.MovimientosInventario", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Productos");

                    b.Navigation("Propietarios");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.MovimientosVenta", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Servicios", "Servicios")
                        .WithMany()
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Ventas", "Ventas")
                        .WithMany()
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietarios");

                    b.Navigation("Servicios");

                    b.Navigation("Usuarios");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Productos", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Medidas", "Medidas")
                        .WithMany()
                        .HasForeignKey("IdMedida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.TipoProducto", "TipoProducto")
                        .WithMany()
                        .HasForeignKey("IdTipoProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medidas");

                    b.Navigation("Propietarios");

                    b.Navigation("TipoProducto");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Proveedores", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Recetas", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Servicios", "Servicios")
                        .WithMany()
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Productos");

                    b.Navigation("Propietarios");

                    b.Navigation("Servicios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Servicios", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.TipoProducto", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietarios");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Usuarios", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietarios");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("P_SGI_BE.Models.Ventas", b =>
                {
                    b.HasOne("P_SGI_BE.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.MetodoPago", "MetodoPago")
                        .WithMany()
                        .HasForeignKey("IdMetodoPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P_SGI_BE.Models.Propietarios", "Propietarios")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("MetodoPago");

                    b.Navigation("Propietarios");
                });
#pragma warning restore 612, 618
        }
    }
}
