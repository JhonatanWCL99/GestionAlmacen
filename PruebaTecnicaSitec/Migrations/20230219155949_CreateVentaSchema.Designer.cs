﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PruebaTecnicaSitec.Data;

#nullable disable

namespace PruebaTecnicaSitec.Migrations
{
    [DbContext(typeof(AlmacenDB))]
    [Migration("20230219155949_CreateVentaSchema")]
    partial class CreateVentaSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PruebaTecnicaSitec.Models.DetalleInventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InventarioId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductoId")
                        .HasColumnType("integer");

                    b.Property<float>("cantidad")
                        .HasColumnType("real");

                    b.Property<float>("subtotal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("InventarioId");

                    b.ToTable("DetallesInventario");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.DetalleInventario", b =>
                {
                    b.HasOne("PruebaTecnicaSitec.Models.Inventario", null)
                        .WithMany("detallesInventario")
                        .HasForeignKey("InventarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PruebaTecnicaSitec.Models.Inventario", b =>
                {
                    b.Navigation("detallesInventario");
                });
#pragma warning restore 612, 618
        }
    }
}
