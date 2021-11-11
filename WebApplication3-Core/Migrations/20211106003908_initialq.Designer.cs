﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3_Core.Model;

namespace WebApplication3_Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211106003908_initialq")]
    partial class initialq
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication3_Core.Model.RouteSearch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSearched")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromStationId")
                        .HasColumnType("int");

                    b.Property<int?>("ToStationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromStationId");

                    b.HasIndex("ToStationId");

                    b.ToTable("RouteSearches");
                });

            modelBuilder.Entity("WebApplication3_Core.Model.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Zero",
                            Name = "Zero"
                        },
                        new
                        {
                            Id = 2,
                            Description = "One",
                            Name = "One"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Two",
                            Name = "Two"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Three",
                            Name = "Three"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Four",
                            Name = "Four"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Five",
                            Name = "Five"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Six",
                            Name = "Six"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Seven",
                            Name = "Seven"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Eight",
                            Name = "Eight"
                        });
                });

            modelBuilder.Entity("WebApplication3_Core.Model.StationLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<float>("Fare")
                        .HasColumnType("real");

                    b.Property<int>("FromStationId")
                        .HasColumnType("int");

                    b.Property<int>("SubwayLine")
                        .HasColumnType("int");

                    b.Property<int>("ToStationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromStationId");

                    b.HasIndex("ToStationId");

                    b.ToTable("StationLinks");
                });

            modelBuilder.Entity("WebApplication3_Core.Model.RouteSearch", b =>
                {
                    b.HasOne("WebApplication3_Core.Model.Station", "FromStation")
                        .WithMany()
                        .HasForeignKey("FromStationId");

                    b.HasOne("WebApplication3_Core.Model.Station", "ToStation")
                        .WithMany()
                        .HasForeignKey("ToStationId");

                    b.Navigation("FromStation");

                    b.Navigation("ToStation");
                });

            modelBuilder.Entity("WebApplication3_Core.Model.StationLink", b =>
                {
                    b.HasOne("WebApplication3_Core.Model.Station", "FromStation")
                        .WithMany()
                        .HasForeignKey("FromStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication3_Core.Model.Station", "ToStation")
                        .WithMany()
                        .HasForeignKey("ToStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromStation");

                    b.Navigation("ToStation");
                });
#pragma warning restore 612, 618
        }
    }
}
