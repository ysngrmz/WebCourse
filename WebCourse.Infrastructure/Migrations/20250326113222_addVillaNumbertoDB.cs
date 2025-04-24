using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebCourse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addVillaNumbertoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumberDB",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    villaID = table.Column<int>(type: "int", nullable: false),
                    specialProperties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumberDB", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumberDB_VillaDB_villaID",
                        column: x => x.villaID,
                        principalTable: "VillaDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VillaNumberDB",
                columns: new[] { "Villa_Number", "specialProperties", "villaID" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 102, null, 1 },
                    { 103, null, 1 },
                    { 201, null, 2 },
                    { 202, null, 2 },
                    { 203, null, 2 },
                    { 301, null, 3 },
                    { 302, null, 3 },
                    { 303, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumberDB_villaID",
                table: "VillaNumberDB",
                column: "villaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumberDB");
        }
    }
}
