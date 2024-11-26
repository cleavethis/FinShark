﻿// <auto-generated />
using System;
using FinShark.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinShark.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241126031938_SecondCreate")]
    partial class SecondCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinShark.Models.Comment", b =>
                {
                    b.Property<int>("commentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentID"));

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("stockId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("commentID");

                    b.HasIndex("stockId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("FinShark.Models.Stock", b =>
                {
                    b.Property<int>("stockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("stockId"));

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("lastDiv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("marketCap")
                        .HasColumnType("bigint");

                    b.Property<decimal>("purchase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("stockId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("FinShark.Models.Comment", b =>
                {
                    b.HasOne("FinShark.Models.Stock", "Stock")
                        .WithMany("comments")
                        .HasForeignKey("stockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("FinShark.Models.Stock", b =>
                {
                    b.Navigation("comments");
                });
#pragma warning restore 612, 618
        }
    }
}