﻿// <auto-generated />
using CatsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatsAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231207162039_CreatedNewRelationship")]
    partial class CreatedNewRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CatsAPI.Models.AddressModel", b =>
                {
                    b.Property<string>("StreetAddress")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CatId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StreetAddress");

                    b.HasIndex("CatId");

                    b.ToTable("AddressModel");
                });

            modelBuilder.Entity("CatsAPI.Models.CatModel", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CatId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("CatsAPI.Models.AddressModel", b =>
                {
                    b.HasOne("CatsAPI.Models.CatModel", "Cat")
                        .WithMany("Addresses")
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cat");
                });

            modelBuilder.Entity("CatsAPI.Models.CatModel", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}