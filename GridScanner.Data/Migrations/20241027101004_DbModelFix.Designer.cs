﻿// <auto-generated />
using System;
using GridScanner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GridScanner.Data.Migrations
{
    [DbContext(typeof(GridScannerDbContext))]
    [Migration("20241027101004_DbModelFix")]
    partial class DbModelFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GridScanner.Models.DayData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Avg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("DayHigh")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DayLow")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DaysData");
                });

            modelBuilder.Entity("GridScanner.Models.HourlyPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DayDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Hour1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour10")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour11")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour12")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour13")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour14")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour15")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour16")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour17")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour18")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour19")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour20")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour21")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour22")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour23")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Hour24")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Hour25")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour3")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour4")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour5")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour6")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour7")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour8")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Hour9")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DayDataId")
                        .IsUnique();

                    b.ToTable("HourlyPrices");
                });

            modelBuilder.Entity("GridScanner.Models.HourlyPrice", b =>
                {
                    b.HasOne("GridScanner.Models.DayData", "DayData")
                        .WithOne("HourlyPrices")
                        .HasForeignKey("GridScanner.Models.HourlyPrice", "DayDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayData");
                });

            modelBuilder.Entity("GridScanner.Models.DayData", b =>
                {
                    b.Navigation("HourlyPrices")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
