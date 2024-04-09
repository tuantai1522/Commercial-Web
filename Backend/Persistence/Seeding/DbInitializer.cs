using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeding
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void SeedCategoryData()
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Shirts"
                },
                 new Category()
                 {
                     Id = 2,
                     Name = "Pants"
                 },
                new Category()
                {
                    Id = 3,
                    Name = "Shoes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Accessories"
                });
        }
        public void SeedProductData()
        {
            modelBuilder.Entity<Product>().HasData(
                   new Product()
                   {
                       Id = 1,
                       Name = "Plaid cropped shirt",
                       Price = 49.90,
                       Description = "Shirt for men",
                       QuantityInStock = 13,
                       ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                       CategoryId = 1

                   },
                   new Product()
                   {
                       Id = 2,
                       Name = "Watercolor print shirt",
                       Price = 59.90,
                       Description = "Shirt for men",
                       QuantityInStock = 1,
                       ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                       CategoryId = 1
                   },
                   new Product()
                   {
                       Id = 3,
                       Name = "Abstract print shirt",
                       Price = 49.90,
                       Description = "Shirt for men and women",
                       QuantityInStock = 0,
                       ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                       CategoryId = 1
                   },
                   new Product()
                   {
                       Id = 4,
                       Name = "Linen shirt",
                       Price = 49.90,
                       Description = "Shirt for kids",
                       QuantityInStock = 23,
                       ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                       CategoryId = 1
                   },
                   new Product()
                   {
                       Id = 5,
                       Name = "Tie-dye print shirt",
                       Price = 69.90,
                       Description = "Shirt for men",
                       QuantityInStock = 23,
                       ImageUrl = "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg",
                       CategoryId = 1
                   },
                   new Product()
                   {
                       Id = 6,
                       Name = "Haggar Men's Cool 18",
                       Price = 30.48,
                       Description = "Pants for men",
                       QuantityInStock = 78,
                       ImageUrl = "https://m.media-amazon.com/images/I/71Z1Tina-LL._AC_SX679_.jpg",
                       CategoryId = 2
                   },
                   new Product()
                   {
                       Id = 7,
                       Name = "HUDSON Men's Blake Slim Straight",
                       Price = 67.49,
                       Description = "Pants for men",
                       QuantityInStock = 23,
                       ImageUrl = "https://m.media-amazon.com/images/I/71wbSqIyuEL._AC_SY741_.jpg",
                       CategoryId = 2
                   },
                   new Product()
                   {
                       Id = 8,
                       Name = "Ergodyne Men's Standard Lightweight Base Layer",
                       Price = 22.49,
                       Description = "Pants for men",
                       QuantityInStock = 1,
                       ImageUrl = "https://m.media-amazon.com/images/I/51OvWUWbfvL._AC_SX679_.jpg",
                       CategoryId = 2
                   },
                   new Product()
                   {
                       Id = 9,
                       Name = "LAPCOFR unisex adult",
                       Price = 66.37,
                       Description = "Pants for men",
                       QuantityInStock = 100,
                       ImageUrl = "https://m.media-amazon.com/images/I/51LtnVXcodL._SX425_.jpg",
                       CategoryId = 2
                   },
                   new Product()
                   {
                       Id = 10,
                       Name = "Essentials Men's Classic-Fit Wrinkle-Resistant",
                       Price = 8.70,
                       Description = "Pants for men",
                       QuantityInStock = 28,
                       ImageUrl = "https://m.media-amazon.com/images/I/81HVw7Pzw9L._AC_SX679_.jpg",
                       CategoryId = 2
                   },
                   new Product()
                   {
                       Id = 11,
                       Name = "Amazon Essentials Women's Loafer Flat",
                       Price = 22.80,
                       Description = "Shoes for women",
                       QuantityInStock = 78,
                       ImageUrl = "https://m.media-amazon.com/images/I/61dM5wEQN1L._AC_SX695_.jpg",
                       CategoryId = 3
                   },
                   new Product()
                   {
                       Id = 12,
                       Name = "Ringside Diablo Wrestling Boxing Shoes",
                       Price = 67.12,
                       Description = "Shoes for adults",
                       QuantityInStock = 48,
                       ImageUrl = "https://m.media-amazon.com/images/I/81TxPZimMaL._AC_SX679_.jpg",
                       CategoryId = 3
                   },
                   new Product()
                   {
                       Id = 13,
                       Name = "MOZO Men's Slip Resistant Chef Natural Shoes",
                       Price = 107.48,
                       Description = "Shoes for men",
                       QuantityInStock = 39,
                       ImageUrl = "https://m.media-amazon.com/images/I/712jIRO8smL._AC_SY695_.jpg",
                       CategoryId = 3
                   },
                   new Product()
                   {
                       Id = 14,
                       Name = "Merrell Men's Moab 3 Tactical Industrial Shoe",
                       Price = 119.95,
                       Description = "Shoes for men",
                       QuantityInStock = 39,
                       ImageUrl = "https://m.media-amazon.com/images/I/61RHHzP07hL._AC_SY695_.jpg",
                       CategoryId = 3
                   },
                   new Product()
                   {
                       Id = 15,
                       Name = "Skechers Men's Afterburn M. Fit",
                       Price = 47.99,
                       Description = "Shoes for men",
                       QuantityInStock = 28,
                       ImageUrl = "https://m.media-amazon.com/images/I/81kHSg8x6jL._AC_SX695_.jpg",
                       CategoryId = 3
                   },
                   new Product()
                   {
                       Id = 16,
                       Name = "Carve Designs Women's Dundee Crushable",
                       Price = 47.00,
                       Description = "Hat for women",
                       QuantityInStock = 34,
                       ImageUrl = "https://m.media-amazon.com/images/I/81FR3EO3-wL._AC_SX679_.jpg",
                       CategoryId = 4
                   },
                   new Product()
                   {
                       Id = 17,
                       Name = "Eddie Bauer Women's Casual Fashion Leather Belt",
                       Price = 32.71,
                       Description = "Belt for women",
                       QuantityInStock = 19,
                       ImageUrl = "https://m.media-amazon.com/images/I/71AOYEcwVyL._AC_SX679_.jpg",
                       CategoryId = 4
                   },
                   new Product()
                   {
                       Id = 18,
                       Name = "French Connection Flex Sunglasses For Women",
                       Price = 11.95,
                       Description = "Sunglasses for women",
                       QuantityInStock = 23,
                       ImageUrl = "https://m.media-amazon.com/images/I/51AGz57VsjL._AC_SX679_.jpg",
                       CategoryId = 4
                   },
                   new Product()
                   {
                       Id = 19,
                       Name = "K. Bell Women's Fun Sport",
                       Price = 8.95,
                       Description = "Socks for kids",
                       QuantityInStock = 89,
                       ImageUrl = "https://m.media-amazon.com/images/I/81v0TUjL2kL._AC_SX679_.jpg",
                       CategoryId = 4
                   },
                   new Product()
                   {
                       Id = 20,
                       Name = "Betsey Johnson Skull Earrings",
                       Price = 26.99,
                       Description = "Earrings for kids",
                       QuantityInStock = 39,
                       ImageUrl = "https://m.media-amazon.com/images/I/71VCEYzU-pL._AC_SY741_.jpg",
                       CategoryId = 4
                   }
            );
        }
    }
}