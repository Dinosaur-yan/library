﻿// <auto-generated />
using System;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.API.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20210425085606_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Library.API.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("48556951-e6b7-44fa-a24b-448cfc4c8c4c"),
                            BirthDate = new DateTimeOffset(new DateTime(1960, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            Email = "author1@xxx.com",
                            Name = "Author 1"
                        },
                        new
                        {
                            Id = new Guid("597e9f16-a810-4c34-98ff-92a53bbebcb9"),
                            BirthDate = new DateTimeOffset(new DateTime(1973, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            Email = "author2@xxx.com",
                            Name = "Author 2"
                        });
                });

            modelBuilder.Entity("Library.API.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a87f37d4-70c1-4d8a-bd34-76ca4194982f"),
                            AuthorId = new Guid("48556951-e6b7-44fa-a24b-448cfc4c8c4c"),
                            Description = "Description of Book 1",
                            Pages = 281,
                            Title = "Book 1"
                        },
                        new
                        {
                            Id = new Guid("c3357824-6d12-4a41-a544-76659e848263"),
                            AuthorId = new Guid("48556951-e6b7-44fa-a24b-448cfc4c8c4c"),
                            Description = "Description of Book 2",
                            Pages = 370,
                            Title = "Book 2"
                        },
                        new
                        {
                            Id = new Guid("e1108d59-2bc3-4f2f-b643-f3d0cb3b7e0b"),
                            AuthorId = new Guid("597e9f16-a810-4c34-98ff-92a53bbebcb9"),
                            Description = "Description of Book 3",
                            Pages = 229,
                            Title = "Book 3"
                        },
                        new
                        {
                            Id = new Guid("f1ea8f47-aed7-4c33-a1c7-8a96abfc89aa"),
                            AuthorId = new Guid("597e9f16-a810-4c34-98ff-92a53bbebcb9"),
                            Description = "Description of Book 4",
                            Pages = 440,
                            Title = "Book 4"
                        });
                });

            modelBuilder.Entity("Library.API.Entities.Book", b =>
                {
                    b.HasOne("Library.API.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}