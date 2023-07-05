﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestWebApp.DataBase;

#nullable disable

namespace TestWebApp.Migrations
{
    [DbContext(typeof(Child_DbContext))]
    partial class Child_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("TestWebApp.Models.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CalculationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateBet")
                        .HasColumnType("TEXT");

                    b.Property<int>("GamerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sum")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Win")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("TestWebApp.Models.Gamer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gamers");
                });

            modelBuilder.Entity("TestWebApp.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("GamerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeOperation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
