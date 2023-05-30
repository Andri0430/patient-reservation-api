﻿// <auto-generated />
using HospitalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalAPI.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20230530103555_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HospitalAPI.Models.Kamar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Kuota")
                        .HasColumnType("int");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PerawatanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerawatanId");

                    b.ToTable("Kamar");
                });

            modelBuilder.Entity("HospitalAPI.Models.Pasien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("KamarId")
                        .HasColumnType("int");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NoHp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NoKtp")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PerawatanId")
                        .HasColumnType("int");

                    b.Property<string>("Usia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("KamarId");

                    b.HasIndex("PerawatanId");

                    b.ToTable("Pasien");
                });

            modelBuilder.Entity("HospitalAPI.Models.Perawatan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NamaPerawatan")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Perawatan");
                });

            modelBuilder.Entity("HospitalAPI.Models.Kamar", b =>
                {
                    b.HasOne("HospitalAPI.Models.Perawatan", "Perawatan")
                        .WithMany()
                        .HasForeignKey("PerawatanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perawatan");
                });

            modelBuilder.Entity("HospitalAPI.Models.Pasien", b =>
                {
                    b.HasOne("HospitalAPI.Models.Kamar", "Kamar")
                        .WithMany("Pasiens")
                        .HasForeignKey("KamarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalAPI.Models.Perawatan", "Perawatan")
                        .WithMany("Pasiens")
                        .HasForeignKey("PerawatanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kamar");

                    b.Navigation("Perawatan");
                });

            modelBuilder.Entity("HospitalAPI.Models.Kamar", b =>
                {
                    b.Navigation("Pasiens");
                });

            modelBuilder.Entity("HospitalAPI.Models.Perawatan", b =>
                {
                    b.Navigation("Pasiens");
                });
#pragma warning restore 612, 618
        }
    }
}