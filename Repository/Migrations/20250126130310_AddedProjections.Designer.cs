﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DbContexts;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(CMartDbContext))]
    [Migration("20250126130310_AddedProjections")]
    partial class AddedProjections
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Domain.Entities.Projection", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectionSource")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SlateID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Team")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SlateID");

                    b.ToTable("Projection");
                });

            modelBuilder.Entity("Domain.Entities.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DFSSiteID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Positions")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SalaryAmount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SlateID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Team")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SlateID");

                    b.ToTable("Salaries", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Slate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("DFSSite")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("GameType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Sport")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Slates", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Projection", b =>
                {
                    b.HasOne("Domain.Entities.Slate", null)
                        .WithMany("Projections")
                        .HasForeignKey("SlateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Domain.ValueTypes.ProjectionData", "Data", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("ProjectionId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("StatCategory")
                                .HasColumnType("INTEGER");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("Id");

                            b1.HasIndex("ProjectionId");

                            b1.ToTable("ProjectionData");

                            b1.WithOwner()
                                .HasForeignKey("ProjectionId");
                        });

                    b.Navigation("Data");
                });

            modelBuilder.Entity("Domain.Entities.Salary", b =>
                {
                    b.HasOne("Domain.Entities.Slate", null)
                        .WithMany("Salaries")
                        .HasForeignKey("SlateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Slate", b =>
                {
                    b.Navigation("Projections");

                    b.Navigation("Salaries");
                });
#pragma warning restore 612, 618
        }
    }
}
