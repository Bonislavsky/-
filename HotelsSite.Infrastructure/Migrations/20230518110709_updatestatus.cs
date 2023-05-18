using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelsSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatestatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NumberTypes",
                keyColumn: "Id",
                keyValue: (short)3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Family room for 3-4 person", "Family" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NumberTypes",
                keyColumn: "Id",
                keyValue: (short)3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Double room for 3-4 person", "Double" });
        }
    }
}
