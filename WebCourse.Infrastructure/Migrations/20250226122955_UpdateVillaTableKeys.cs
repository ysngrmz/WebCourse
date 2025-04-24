using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCourse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVillaTableKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "VillaDB",
                newName: "Updated_Date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "VillaDB",
                newName: "Created_Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_Date",
                table: "VillaDB",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Created_Date",
                table: "VillaDB",
                newName: "CreatedDate");
        }
    }
}
