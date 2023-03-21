﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCA_Asigurari.Data;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    [DbContext(typeof(RCA_AsigurariContext))]
    [Migration("20230321092854_pf")]
    partial class pf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RCA_Asigurari.Models.CategorieVehicul", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoriaVehicul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CategorieVehicul");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ActivitateSocietate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JudetID")
                        .HasColumnType("int");

                    b.Property<int>("LocalitateID")
                        .HasColumnType("int");

                    b.Property<string>("Numar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarCI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeFirma")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NumeProprietar")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NumeReprezentantFirma")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PrenumeProprietar")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PrenumeReprezentantFirma")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SerieCI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strada")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipAsiguratID")
                        .HasColumnType("int");

                    b.Property<int?>("TipSocietateID")
                        .HasColumnType("int");

                    b.Property<string>("Varsta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("JudetID");

                    b.HasIndex("LocalitateID");

                    b.HasIndex("TipAsiguratID");

                    b.HasIndex("TipSocietateID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Judet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Judetul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Judet");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Localitate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("JudetID")
                        .HasColumnType("int");

                    b.Property<string>("Localitatea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("JudetID");

                    b.ToTable("Localitate");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.PersoanaFizica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<int?>("JudetID")
                        .HasColumnType("int");

                    b.Property<int?>("LocalitateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("JudetID");

                    b.HasIndex("LocalitateID");

                    b.ToTable("PersoanaFizica");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.TipAsigurat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TipulAsigurat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipAsigurat");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.TipCombustibil", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TipulCombustibil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipCombustibil");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.TipSocietate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("TipulSocietate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipSocietate");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Client", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.Judet", "Judet")
                        .WithMany()
                        .HasForeignKey("JudetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCA_Asigurari.Models.Localitate", "Localitate")
                        .WithMany()
                        .HasForeignKey("LocalitateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCA_Asigurari.Models.TipAsigurat", "TipAsigurat")
                        .WithMany()
                        .HasForeignKey("TipAsiguratID");

                    b.HasOne("RCA_Asigurari.Models.TipSocietate", "TipSocietate")
                        .WithMany()
                        .HasForeignKey("TipSocietateID");

                    b.Navigation("Judet");

                    b.Navigation("Localitate");

                    b.Navigation("TipAsigurat");

                    b.Navigation("TipSocietate");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Localitate", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.Judet", "Judet")
                        .WithMany()
                        .HasForeignKey("JudetID");

                    b.Navigation("Judet");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.PersoanaFizica", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("RCA_Asigurari.Models.Judet", "Judet")
                        .WithMany()
                        .HasForeignKey("JudetID");

                    b.HasOne("RCA_Asigurari.Models.Localitate", "Localitate")
                        .WithMany()
                        .HasForeignKey("LocalitateID");

                    b.Navigation("Client");

                    b.Navigation("Judet");

                    b.Navigation("Localitate");
                });
#pragma warning restore 612, 618
        }
    }
}
