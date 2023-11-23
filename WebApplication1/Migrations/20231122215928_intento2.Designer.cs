﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShorter.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(URLShortContext))]
    [Migration("20231122215928_intento2")]
    partial class intento2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("UrlShortener.entities.Url", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlLong")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlShort")
                        .HasColumnType("TEXT");

                    b.Property<int>("contador")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdUser");

                    b.ToTable("Urls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdCategoria = 1,
                            IdUser = 1,
                            UrlLong = "Lafsdfsft",
                            UrlShort = "llolo",
                            contador = 0
                        },
                        new
                        {
                            Id = 2,
                            IdCategoria = 2,
                            IdUser = 2,
                            UrlLong = "serdgrgfd",
                            UrlShort = "Karen baila piola",
                            contador = 1
                        },
                        new
                        {
                            Id = 3,
                            IdCategoria = 2,
                            IdUser = 2,
                            UrlLong = "sdsdsdsdauuuu",
                            UrlShort = "asddsadsa",
                            contador = 2
                        });
                });

            modelBuilder.Entity("UrlShorter.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Trabajo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Diversion"
                        });
                });

            modelBuilder.Entity("UrlShorter.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RolUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pancho",
                            Password = "password",
                            RolUser = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jose luis",
                            Password = "password",
                            RolUser = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Guest",
                            Password = "password",
                            RolUser = 2
                        });
                });

            modelBuilder.Entity("UrlShortener.entities.Url", b =>
                {
                    b.HasOne("UrlShorter.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UrlShorter.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
