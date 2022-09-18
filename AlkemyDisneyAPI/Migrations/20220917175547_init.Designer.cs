﻿// <auto-generated />
using System;
using ContactsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlkemyDisneyAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220917175547_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("AlkemyDisneyAPI.Models.Character", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("AlkemyDisneyAPI.Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Rating")
                        .HasColumnType("REAL");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("AlkemyDisneyAPI.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("CharacterFilm", b =>
                {
                    b.Property<int>("CharactersID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FilmsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharactersID", "FilmsID");

                    b.HasIndex("FilmsID");

                    b.ToTable("CharacterFilm");
                });

            modelBuilder.Entity("AlkemyDisneyAPI.Models.Film", b =>
                {
                    b.HasOne("AlkemyDisneyAPI.Models.Genre", "Genre")
                        .WithMany("Films")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("CharacterFilm", b =>
                {
                    b.HasOne("AlkemyDisneyAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlkemyDisneyAPI.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlkemyDisneyAPI.Models.Genre", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
