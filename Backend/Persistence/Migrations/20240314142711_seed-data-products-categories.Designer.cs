﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240314142711_seed-data-products-categories")]
    partial class seeddataproductscategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shirts"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pants"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Shoes"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Accessories"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Description = "Shirt for men",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Plaid cropped shirt",
                            Price = 49.899999999999999,
                            QuantityInStock = 13
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 1,
                            Description = "Shirt for men",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Watercolor print shirt",
                            Price = 59.899999999999999,
                            QuantityInStock = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 1,
                            Description = "Shirt for men and women",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Abstract print shirt",
                            Price = 49.899999999999999,
                            QuantityInStock = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryID = 1,
                            Description = "Shirt for kids",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Linen shirt",
                            Price = 49.899999999999999,
                            QuantityInStock = 23
                        },
                        new
                        {
                            Id = 5,
                            CategoryID = 1,
                            Description = "Shirt for men",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Tie-dye print shirt",
                            Price = 69.900000000000006,
                            QuantityInStock = 23
                        },
                        new
                        {
                            Id = 6,
                            CategoryID = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/71Z1Tina-LL._AC_SX679_.jpg",
                            Name = "Haggar Men's Cool 18",
                            Price = 30.48,
                            QuantityInStock = 78
                        },
                        new
                        {
                            Id = 7,
                            CategoryID = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/71wbSqIyuEL._AC_SY741_.jpg",
                            Name = "HUDSON Men's Blake Slim Straight",
                            Price = 67.489999999999995,
                            QuantityInStock = 23
                        },
                        new
                        {
                            Id = 8,
                            CategoryID = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/51OvWUWbfvL._AC_SX679_.jpg",
                            Name = "Ergodyne Men's Standard Lightweight Base Layer",
                            Price = 22.489999999999998,
                            QuantityInStock = 1
                        },
                        new
                        {
                            Id = 9,
                            CategoryID = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/51LtnVXcodL._SX425_.jpg",
                            Name = "LAPCOFR unisex adult",
                            Price = 66.370000000000005,
                            QuantityInStock = 100
                        },
                        new
                        {
                            Id = 10,
                            CategoryID = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/81HVw7Pzw9L._AC_SX679_.jpg",
                            Name = "Essentials Men's Classic-Fit Wrinkle-Resistant",
                            Price = 8.6999999999999993,
                            QuantityInStock = 28
                        },
                        new
                        {
                            Id = 11,
                            CategoryID = 3,
                            Description = "Shoes for women",
                            ImageUrl = "https://m.media-amazon.com/images/I/61dM5wEQN1L._AC_SX695_.jpg",
                            Name = "Amazon Essentials Women's Loafer Flat",
                            Price = 22.800000000000001,
                            QuantityInStock = 78
                        },
                        new
                        {
                            Id = 12,
                            CategoryID = 3,
                            Description = "Shoes for adults",
                            ImageUrl = "https://m.media-amazon.com/images/I/81TxPZimMaL._AC_SX679_.jpg",
                            Name = "Ringside Diablo Wrestling Boxing Shoes",
                            Price = 67.120000000000005,
                            QuantityInStock = 48
                        },
                        new
                        {
                            Id = 13,
                            CategoryID = 3,
                            Description = "Shoes for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/712jIRO8smL._AC_SY695_.jpg",
                            Name = "MOZO Men's Slip Resistant Chef Natural Shoes",
                            Price = 107.48,
                            QuantityInStock = 39
                        },
                        new
                        {
                            Id = 14,
                            CategoryID = 3,
                            Description = "Shoes for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/61RHHzP07hL._AC_SY695_.jpg",
                            Name = "Merrell Men's Moab 3 Tactical Industrial Shoe",
                            Price = 119.95,
                            QuantityInStock = 39
                        },
                        new
                        {
                            Id = 15,
                            CategoryID = 3,
                            Description = "Shoes for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/81kHSg8x6jL._AC_SX695_.jpg",
                            Name = "Skechers Men's Afterburn M. Fit",
                            Price = 47.990000000000002,
                            QuantityInStock = 28
                        },
                        new
                        {
                            Id = 16,
                            CategoryID = 4,
                            Description = "Hat for women",
                            ImageUrl = "https://m.media-amazon.com/images/I/81FR3EO3-wL._AC_SX679_.jpg",
                            Name = "Carve Designs Women's Dundee Crushable",
                            Price = 47.0,
                            QuantityInStock = 34
                        },
                        new
                        {
                            Id = 17,
                            CategoryID = 4,
                            Description = "Belt for women",
                            ImageUrl = "https://m.media-amazon.com/images/I/71AOYEcwVyL._AC_SX679_.jpg",
                            Name = "Eddie Bauer Women's Casual Fashion Leather Belt",
                            Price = 32.710000000000001,
                            QuantityInStock = 19
                        },
                        new
                        {
                            Id = 18,
                            CategoryID = 4,
                            Description = "Sunglasses for women",
                            ImageUrl = "https://m.media-amazon.com/images/I/51AGz57VsjL._AC_SX679_.jpg",
                            Name = "French Connection Flex Sunglasses For Women",
                            Price = 11.949999999999999,
                            QuantityInStock = 23
                        },
                        new
                        {
                            Id = 19,
                            CategoryID = 4,
                            Description = "Socks for kids",
                            ImageUrl = "https://m.media-amazon.com/images/I/81v0TUjL2kL._AC_SX679_.jpg",
                            Name = "K. Bell Women's Fun Sport",
                            Price = 8.9499999999999993,
                            QuantityInStock = 89
                        },
                        new
                        {
                            Id = 20,
                            CategoryID = 4,
                            Description = "Earrings for kids",
                            ImageUrl = "https://m.media-amazon.com/images/I/71VCEYzU-pL._AC_SY741_.jpg",
                            Name = "Betsey Johnson Skull Earrings",
                            Price = 26.989999999999998,
                            QuantityInStock = 39
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
