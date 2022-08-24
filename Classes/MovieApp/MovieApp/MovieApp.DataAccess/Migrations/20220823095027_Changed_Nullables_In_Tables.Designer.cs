﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.DataAccess.Data;

#nullable disable

namespace MovieApp.DataAccess.Migrations
{
    [DbContext(typeof(MovieAppDbContext))]
    [Migration("20220823095027_Changed_Nullables_In_Tables")]
    partial class Changed_Nullables_In_Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieApp.Domain.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Greg Focker and his fiancee Pam decide to make their respective parents meet before their wedding. However, the Fockers' relaxed attitude does not go down well with Pam's family.",
                            Genre = 1,
                            Title = "Meet the Fockers",
                            Year = 2004
                        },
                        new
                        {
                            Id = 2,
                            Description = "James takes Ben along to pull the plug on a drug racket involving an influential businessman, Antonio Pope. However, with Ben's wedding day approaching, the two have little time to expose the crime.",
                            Genre = 1,
                            Title = "Ride Along 2",
                            Year = 2016
                        },
                        new
                        {
                            Id = 3,
                            Description = "In the world of international crime, an Interpol agent attempts to hunt down and capture the world's most wanted art thief.",
                            Genre = 2,
                            Title = "Red Notice",
                            Year = 2021
                        },
                        new
                        {
                            Id = 4,
                            Description = "Victor Sullivan recruits Nathan Drake to help him find the lost fortune of Ferdinand Magellan. However, they face competition from Santiago Moncada, who believes that the treasure belongs to him.",
                            Genre = 3,
                            Title = "Uncharted",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("MovieApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FavouriteGenre")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FavouriteGenre = 0,
                            FirstName = "Ilija",
                            LastName = "Mitev",
                            Password = "ilija123",
                            Username = "ilija123"
                        });
                });

            modelBuilder.Entity("MovieApp.Domain.Models.UserMovie", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersMovies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            UserId = 1,
                            Id = 1
                        },
                        new
                        {
                            MovieId = 2,
                            UserId = 1,
                            Id = 2
                        },
                        new
                        {
                            MovieId = 3,
                            UserId = 1,
                            Id = 3
                        });
                });

            modelBuilder.Entity("MovieApp.Domain.Models.UserMovie", b =>
                {
                    b.HasOne("MovieApp.Domain.Models.Movie", "Movie")
                        .WithMany("UserMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.Domain.Models.User", "User")
                        .WithMany("UserMovies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieApp.Domain.Models.Movie", b =>
                {
                    b.Navigation("UserMovies");
                });

            modelBuilder.Entity("MovieApp.Domain.Models.User", b =>
                {
                    b.Navigation("UserMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
