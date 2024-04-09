﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

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

                    b.Property<int>("CategoryId")
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

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Shirt for men",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Plaid cropped shirt",
                            Price = 49.899999999999999,
                            QuantityInStock = 13
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Shirt for men",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Watercolor print shirt",
                            Price = 59.899999999999999,
                            QuantityInStock = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Shirt for men and women",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Abstract print shirt",
                            Price = 49.899999999999999,
                            QuantityInStock = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Shirt for kids",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Linen shirt",
                            Price = 49.899999999999999,
                            QuantityInStock = 23
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Shirt for men",
                            ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                            Name = "Tie-dye print shirt",
                            Price = 69.900000000000006,
                            QuantityInStock = 23
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/71Z1Tina-LL._AC_SX679_.jpg",
                            Name = "Haggar Men's Cool 18",
                            Price = 30.48,
                            QuantityInStock = 78
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/71wbSqIyuEL._AC_SY741_.jpg",
                            Name = "HUDSON Men's Blake Slim Straight",
                            Price = 67.489999999999995,
                            QuantityInStock = 23
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/51OvWUWbfvL._AC_SX679_.jpg",
                            Name = "Ergodyne Men's Standard Lightweight Base Layer",
                            Price = 22.489999999999998,
                            QuantityInStock = 1
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/51LtnVXcodL._SX425_.jpg",
                            Name = "LAPCOFR unisex adult",
                            Price = 66.370000000000005,
                            QuantityInStock = 100
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "Pants for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/81HVw7Pzw9L._AC_SX679_.jpg",
                            Name = "Essentials Men's Classic-Fit Wrinkle-Resistant",
                            Price = 8.6999999999999993,
                            QuantityInStock = 28
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "Shoes for women",
                            ImageUrl = "https://m.media-amazon.com/images/I/61dM5wEQN1L._AC_SX695_.jpg",
                            Name = "Amazon Essentials Women's Loafer Flat",
                            Price = 22.800000000000001,
                            QuantityInStock = 78
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "Shoes for adults",
                            ImageUrl = "https://m.media-amazon.com/images/I/81TxPZimMaL._AC_SX679_.jpg",
                            Name = "Ringside Diablo Wrestling Boxing Shoes",
                            Price = 67.120000000000005,
                            QuantityInStock = 48
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Description = "Shoes for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/712jIRO8smL._AC_SY695_.jpg",
                            Name = "MOZO Men's Slip Resistant Chef Natural Shoes",
                            Price = 107.48,
                            QuantityInStock = 39
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            Description = "Shoes for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/61RHHzP07hL._AC_SY695_.jpg",
                            Name = "Merrell Men's Moab 3 Tactical Industrial Shoe",
                            Price = 119.95,
                            QuantityInStock = 39
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Description = "Shoes for men",
                            ImageUrl = "https://m.media-amazon.com/images/I/81kHSg8x6jL._AC_SX695_.jpg",
                            Name = "Skechers Men's Afterburn M. Fit",
                            Price = 47.990000000000002,
                            QuantityInStock = 28
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            Description = "Hat for women",
                            ImageUrl = "https://m.media-amazon.com/images/I/81FR3EO3-wL._AC_SX679_.jpg",
                            Name = "Carve Designs Women's Dundee Crushable",
                            Price = 47.0,
                            QuantityInStock = 34
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            Description = "Belt for women",
                            ImageUrl = "https://m.media-amazon.com/images/I/71AOYEcwVyL._AC_SX679_.jpg",
                            Name = "Eddie Bauer Women's Casual Fashion Leather Belt",
                            Price = 32.710000000000001,
                            QuantityInStock = 19
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Description = "Sunglasses for women",
                            ImageUrl = "https://m.media-amazon.com/images/I/51AGz57VsjL._AC_SX679_.jpg",
                            Name = "French Connection Flex Sunglasses For Women",
                            Price = 11.949999999999999,
                            QuantityInStock = 23
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            Description = "Socks for kids",
                            ImageUrl = "https://m.media-amazon.com/images/I/81v0TUjL2kL._AC_SX679_.jpg",
                            Name = "K. Bell Women's Fun Sport",
                            Price = 8.9499999999999993,
                            QuantityInStock = 89
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Description = "Earrings for kids",
                            ImageUrl = "https://m.media-amazon.com/images/I/71VCEYzU-pL._AC_SY741_.jpg",
                            Name = "Betsey Johnson Skull Earrings",
                            Price = 26.989999999999998,
                            QuantityInStock = 39
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d99d29df-3225-49fe-af57-7657ecbb9be1",
                            ConcurrencyStamp = "743f29fb-35d2-476f-a340-fb2d2f0d868b",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        },
                        new
                        {
                            Id = "21576d7f-6383-4c76-8c38-0434ff8508fb",
                            ConcurrencyStamp = "ca605b3b-0dca-4c14-8fcb-7907a84aed5c",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");

                    b.HasData(
                        new
                        {
                            Id = "661bbdae-c571-423a-8e05-6cbc593e7418",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d5dd7181-5aab-4598-a21c-1aa5e526c19a",
                            Email = "Jonas@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "123456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "46ba4265-76af-4ee3-bcf3-b2af2fa45188",
                            TwoFactorEnabled = false,
                            UserName = "Jonas"
                        },
                        new
                        {
                            Id = "28a6d560-f547-4a88-8fdf-80c1bd6f94f7",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2ea0ca14-1115-4c82-8637-5e6d3d93dcdd",
                            Email = "Admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "123456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "15135916-301e-41c4-be3f-e05306a93aeb",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CartItem", b =>
                {
                    b.HasOne("Domain.Entities.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
