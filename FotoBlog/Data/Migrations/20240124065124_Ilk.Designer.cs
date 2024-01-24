﻿// <auto-generated />
using FotoBlog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FotoBlog.Data.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20240124065124_Ilk")]
    partial class Ilk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FotoBlog.Data.Gonderi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimYolu")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Gonderiler");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Baslik = "Batarken güneş ardında tepelerin, veda vakti geldi teletabilerin..",
                            ResimYolu = "01.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Baslik = "Mutlu gamsız yaşar kuşlar. Yuvaları ağaçlar taşlar.",
                            ResimYolu = "02.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}