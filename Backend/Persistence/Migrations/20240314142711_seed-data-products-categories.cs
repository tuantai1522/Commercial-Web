using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class seeddataproductscategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Shirts" },
                    { 2, "Pants" },
                    { 3, "Shoes" },
                    { 4, "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, 1, "Shirt for men", "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg", "Plaid cropped shirt", 49.899999999999999, 13 },
                    { 2, 1, "Shirt for men", "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg", "Watercolor print shirt", 59.899999999999999, 1 },
                    { 3, 1, "Shirt for men and women", "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg", "Abstract print shirt", 49.899999999999999, 0 },
                    { 4, 1, "Shirt for kids", "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg", "Linen shirt", 49.899999999999999, 23 },
                    { 5, 1, "Shirt for men", "https://img.fantaskycdn.com/cf56af93a6490ab8b6831b9271859224_750x.jpg", "Tie-dye print shirt", 69.900000000000006, 23 },
                    { 6, 2, "Pants for men", "https://m.media-amazon.com/images/I/71Z1Tina-LL._AC_SX679_.jpg", "Haggar Men's Cool 18", 30.48, 78 },
                    { 7, 2, "Pants for men", "https://m.media-amazon.com/images/I/71wbSqIyuEL._AC_SY741_.jpg", "HUDSON Men's Blake Slim Straight", 67.489999999999995, 23 },
                    { 8, 2, "Pants for men", "https://m.media-amazon.com/images/I/51OvWUWbfvL._AC_SX679_.jpg", "Ergodyne Men's Standard Lightweight Base Layer", 22.489999999999998, 1 },
                    { 9, 2, "Pants for men", "https://m.media-amazon.com/images/I/51LtnVXcodL._SX425_.jpg", "LAPCOFR unisex adult", 66.370000000000005, 100 },
                    { 10, 2, "Pants for men", "https://m.media-amazon.com/images/I/81HVw7Pzw9L._AC_SX679_.jpg", "Essentials Men's Classic-Fit Wrinkle-Resistant", 8.6999999999999993, 28 },
                    { 11, 3, "Shoes for women", "https://m.media-amazon.com/images/I/61dM5wEQN1L._AC_SX695_.jpg", "Amazon Essentials Women's Loafer Flat", 22.800000000000001, 78 },
                    { 12, 3, "Shoes for adults", "https://m.media-amazon.com/images/I/81TxPZimMaL._AC_SX679_.jpg", "Ringside Diablo Wrestling Boxing Shoes", 67.120000000000005, 48 },
                    { 13, 3, "Shoes for men", "https://m.media-amazon.com/images/I/712jIRO8smL._AC_SY695_.jpg", "MOZO Men's Slip Resistant Chef Natural Shoes", 107.48, 39 },
                    { 14, 3, "Shoes for men", "https://m.media-amazon.com/images/I/61RHHzP07hL._AC_SY695_.jpg", "Merrell Men's Moab 3 Tactical Industrial Shoe", 119.95, 39 },
                    { 15, 3, "Shoes for men", "https://m.media-amazon.com/images/I/81kHSg8x6jL._AC_SX695_.jpg", "Skechers Men's Afterburn M. Fit", 47.990000000000002, 28 },
                    { 16, 4, "Hat for women", "https://m.media-amazon.com/images/I/81FR3EO3-wL._AC_SX679_.jpg", "Carve Designs Women's Dundee Crushable", 47.0, 34 },
                    { 17, 4, "Belt for women", "https://m.media-amazon.com/images/I/71AOYEcwVyL._AC_SX679_.jpg", "Eddie Bauer Women's Casual Fashion Leather Belt", 32.710000000000001, 19 },
                    { 18, 4, "Sunglasses for women", "https://m.media-amazon.com/images/I/51AGz57VsjL._AC_SX679_.jpg", "French Connection Flex Sunglasses For Women", 11.949999999999999, 23 },
                    { 19, 4, "Socks for kids", "https://m.media-amazon.com/images/I/81v0TUjL2kL._AC_SX679_.jpg", "K. Bell Women's Fun Sport", 8.9499999999999993, 89 },
                    { 20, 4, "Earrings for kids", "https://m.media-amazon.com/images/I/71VCEYzU-pL._AC_SY741_.jpg", "Betsey Johnson Skull Earrings", 26.989999999999998, 39 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");
        }
    }
}
