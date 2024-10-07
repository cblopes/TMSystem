﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMS.Data.Context;

#nullable disable

namespace TMS.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241006235643_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("TMS.Business.Entities.Ocorrencia", b =>
                {
                    b.Property<int>("IdOcorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HoraOcorrencia")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdPedido")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IndFinalizadora")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoOcorrencia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("IdOcorrencia");

                    b.HasIndex("IdPedido");

                    b.ToTable("Ocorrencias", (string)null);
                });

            modelBuilder.Entity("TMS.Business.Entities.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HoraPedido")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IndCancelado")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IndConcluido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdPedido");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("TMS.Business.Entities.Ocorrencia", b =>
                {
                    b.HasOne("TMS.Business.Entities.Pedido", "Pedido")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("IdPedido")
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("TMS.Business.Entities.Pedido", b =>
                {
                    b.Navigation("Ocorrencias");
                });
#pragma warning restore 612, 618
        }
    }
}
