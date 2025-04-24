using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebCourse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultDataToVillaDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VillaDB",
                columns: new[] { "Id", "Created_Date", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "Updated_Date" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Muhteşem deniz manzarasına sahip, geniş bahçeli ve özel havuzlu lüks villa.", "https://example.com/villa1.jpg", "Deniz Manzaralı Lüks Villa", 8, 1500000.0, 3500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doğayla iç içe, huzurlu bir ortamda bulunan, orman manzaralı villa.", "https://example.com/villa2.jpg", "Orman İçinde Sakin Villa", 6, 950000.0, 2200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şehir merkezine kolay ulaşım sağlayan, modern tasarımlı ve geniş teraslı villa.", "https://example.com/villa3.jpg", "Şehir Merkezine Yakın Modern Villa", 7, 1200000.0, 2800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VillaDB",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VillaDB",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VillaDB",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
