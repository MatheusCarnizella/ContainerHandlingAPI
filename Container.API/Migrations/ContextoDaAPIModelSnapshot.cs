﻿// <auto-generated />
using System;
using Container.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Container.API.Migrations
{
    [DbContext(typeof(ContextoDaAPI))]
    partial class ContextoDaAPIModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Container.Domain.Entities.Containers", b =>
                {
                    b.Property<int>("containerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("containerId"));

                    b.Property<string>("clienteNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("containerCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("containerNumero")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("containerStatusVazio")
                        .HasColumnType("bit");

                    b.Property<string>("containerTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("containerId");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("Container.Domain.Entities.Movimentacao", b =>
                {
                    b.Property<int>("movimentacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movimentacaoId"));

                    b.Property<int>("containerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("movimentacaoFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("movimentacaoInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("movimentacaoTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("movimentacaoId");

                    b.HasIndex("containerId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("Container.Domain.Entities.Movimentacao", b =>
                {
                    b.HasOne("Container.Domain.Entities.Containers", "Container")
                        .WithMany("Movimentacao")
                        .HasForeignKey("containerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");
                });

            modelBuilder.Entity("Container.Domain.Entities.Containers", b =>
                {
                    b.Navigation("Movimentacao");
                });
#pragma warning restore 612, 618
        }
    }
}