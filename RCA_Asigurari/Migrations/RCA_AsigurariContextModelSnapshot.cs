﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCA_Asigurari.Data;

#nullable disable

namespace RCA_Asigurari.Migrations
{
    [DbContext(typeof(RCA_AsigurariContext))]
    partial class RCA_AsigurariContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RCA_Asigurari.Models.AtributOptional", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AtributulOptional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AtributOptional");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.AtributOptionalOferta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AtributOptionalID")
                        .HasColumnType("int");

                    b.Property<int>("OfertaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AtributOptionalID");

                    b.HasIndex("OfertaID");

                    b.ToTable("AtributOptionalOferta");
                });

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

            modelBuilder.Entity("RCA_Asigurari.Models.Oferta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AnFabricatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CapacitateCilindrica")
                        .HasColumnType("int");

                    b.Property<int?>("CategorieVehiculID")
                        .HasColumnType("int");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasaMaxima")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrInmatriculare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrLocuri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarIdentificare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pret")
                        .HasColumnType("int");

                    b.Property<string>("Putere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerieCIV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipCombustibilID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieVehiculID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TipCombustibilID");

                    b.ToTable("Oferta");
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

            modelBuilder.Entity("RCA_Asigurari.Models.PersoanaJuridica", b =>
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

                    b.Property<int?>("TipSocietateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("JudetID");

                    b.HasIndex("LocalitateID");

                    b.HasIndex("TipSocietateID");

                    b.ToTable("PersoanaJuridica");
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

            modelBuilder.Entity("RCA_Asigurari.Models.Vehicul", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("OfertaID")
                        .HasColumnType("int");

                    b.Property<int?>("TipCombustibilID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OfertaID");

                    b.HasIndex("TipCombustibilID");

                    b.ToTable("Vehicul");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.AtributOptionalOferta", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.AtributOptional", "AtributOptional")
                        .WithMany("AtributeOptionaleOferta")
                        .HasForeignKey("AtributOptionalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCA_Asigurari.Models.Oferta", "Oferta")
                        .WithMany("AtributeOptionaleOferta")
                        .HasForeignKey("OfertaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AtributOptional");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Client", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.Judet", "Judet")
                        .WithMany("Clienti")
                        .HasForeignKey("JudetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCA_Asigurari.Models.Localitate", "Localitate")
                        .WithMany("Clienti")
                        .HasForeignKey("LocalitateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCA_Asigurari.Models.TipAsigurat", "TipAsigurat")
                        .WithMany("Clienti")
                        .HasForeignKey("TipAsiguratID");

                    b.HasOne("RCA_Asigurari.Models.TipSocietate", "TipSocietate")
                        .WithMany("Clienti")
                        .HasForeignKey("TipSocietateID");

                    b.Navigation("Judet");

                    b.Navigation("Localitate");

                    b.Navigation("TipAsigurat");

                    b.Navigation("TipSocietate");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Localitate", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.Judet", "Judet")
                        .WithMany("Localitati")
                        .HasForeignKey("JudetID");

                    b.Navigation("Judet");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Oferta", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.CategorieVehicul", "CategorieVehicul")
                        .WithMany("Oferte")
                        .HasForeignKey("CategorieVehiculID");

                    b.HasOne("RCA_Asigurari.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("RCA_Asigurari.Models.TipCombustibil", "TipCombustibil")
                        .WithMany("Oferte")
                        .HasForeignKey("TipCombustibilID");

                    b.Navigation("CategorieVehicul");

                    b.Navigation("Client");

                    b.Navigation("TipCombustibil");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.PersoanaFizica", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.Client", "Client")
                        .WithMany("PersoaneFizice")
                        .HasForeignKey("ClientID");

                    b.HasOne("RCA_Asigurari.Models.Judet", "Judet")
                        .WithMany("PersoaneFizice")
                        .HasForeignKey("JudetID");

                    b.HasOne("RCA_Asigurari.Models.Localitate", "Localitate")
                        .WithMany("PersoaneFizice")
                        .HasForeignKey("LocalitateID");

                    b.Navigation("Client");

                    b.Navigation("Judet");

                    b.Navigation("Localitate");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.PersoanaJuridica", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.Client", "Client")
                        .WithMany("PersoaneJuridice")
                        .HasForeignKey("ClientID");

                    b.HasOne("RCA_Asigurari.Models.Judet", "Judet")
                        .WithMany("PersoaneJuridice")
                        .HasForeignKey("JudetID");

                    b.HasOne("RCA_Asigurari.Models.Localitate", "Localitate")
                        .WithMany("PersoaneJuridice")
                        .HasForeignKey("LocalitateID");

                    b.HasOne("RCA_Asigurari.Models.TipSocietate", "TipSocietate")
                        .WithMany("PersoaneJuridice")
                        .HasForeignKey("TipSocietateID");

                    b.Navigation("Client");

                    b.Navigation("Judet");

                    b.Navigation("Localitate");

                    b.Navigation("TipSocietate");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Vehicul", b =>
                {
                    b.HasOne("RCA_Asigurari.Models.Oferta", "Oferte")
                        .WithMany()
                        .HasForeignKey("OfertaID");

                    b.HasOne("RCA_Asigurari.Models.TipCombustibil", null)
                        .WithMany("Vehicule")
                        .HasForeignKey("TipCombustibilID");

                    b.Navigation("Oferte");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.AtributOptional", b =>
                {
                    b.Navigation("AtributeOptionaleOferta");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.CategorieVehicul", b =>
                {
                    b.Navigation("Oferte");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Client", b =>
                {
                    b.Navigation("PersoaneFizice");

                    b.Navigation("PersoaneJuridice");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Judet", b =>
                {
                    b.Navigation("Clienti");

                    b.Navigation("Localitati");

                    b.Navigation("PersoaneFizice");

                    b.Navigation("PersoaneJuridice");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Localitate", b =>
                {
                    b.Navigation("Clienti");

                    b.Navigation("PersoaneFizice");

                    b.Navigation("PersoaneJuridice");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.Oferta", b =>
                {
                    b.Navigation("AtributeOptionaleOferta");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.TipAsigurat", b =>
                {
                    b.Navigation("Clienti");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.TipCombustibil", b =>
                {
                    b.Navigation("Oferte");

                    b.Navigation("Vehicule");
                });

            modelBuilder.Entity("RCA_Asigurari.Models.TipSocietate", b =>
                {
                    b.Navigation("Clienti");

                    b.Navigation("PersoaneJuridice");
                });
#pragma warning restore 612, 618
        }
    }
}
