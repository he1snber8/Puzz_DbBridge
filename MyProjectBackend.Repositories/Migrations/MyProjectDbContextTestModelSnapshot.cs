﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProjectBackend.Repositories;

#nullable disable

namespace MyProjectBackend.Repositories.Migrations
{
    [DbContext(typeof(MyProjectDbContextTest))]
    partial class MyProjectDbContextTestModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("MyProjectBackend.DTO.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("MyProjectBackend.DTO.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ChatEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChatHistory")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<DateTime>("ChatStart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<int>("User1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User2Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("User1Id");

                    b.HasIndex("User2Id", "User1Id")
                        .IsUnique();

                    b.ToTable("Matches", (string)null);
                });

            modelBuilder.Entity("MyProjectBackend.DTO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyProjectBackend.DTO.UserInterest", b =>
                {
                    b.Property<int>("InterestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("InterestId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInterests");
                });

            modelBuilder.Entity("MyProjectBackend.DTO.Match", b =>
                {
                    b.HasOne("MyProjectBackend.DTO.User", "User1")
                        .WithMany()
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyProjectBackend.DTO.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("MyProjectBackend.DTO.UserInterest", b =>
                {
                    b.HasOne("MyProjectBackend.DTO.Interest", "Interest")
                        .WithMany("UserInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyProjectBackend.DTO.User", "User")
                        .WithMany("UserInterests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyProjectBackend.DTO.Interest", b =>
                {
                    b.Navigation("UserInterests");
                });

            modelBuilder.Entity("MyProjectBackend.DTO.User", b =>
                {
                    b.Navigation("UserInterests");
                });
#pragma warning restore 612, 618
        }
    }
}
