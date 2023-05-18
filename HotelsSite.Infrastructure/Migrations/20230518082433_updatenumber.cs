using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelsSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "NumberStatusId",
                table: "HotelNumbers",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "NumberTypeId",
                table: "HotelNumbers",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelNumbers_NumberStatusId",
                table: "HotelNumbers",
                column: "NumberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelNumbers_NumberTypeId",
                table: "HotelNumbers",
                column: "NumberTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelNumbers_NumberStatuses_NumberStatusId",
                table: "HotelNumbers",
                column: "NumberStatusId",
                principalTable: "NumberStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelNumbers_NumberTypes_NumberTypeId",
                table: "HotelNumbers",
                column: "NumberTypeId",
                principalTable: "NumberTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelNumbers_NumberStatuses_NumberStatusId",
                table: "HotelNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelNumbers_NumberTypes_NumberTypeId",
                table: "HotelNumbers");

            migrationBuilder.DropIndex(
                name: "IX_HotelNumbers_NumberStatusId",
                table: "HotelNumbers");

            migrationBuilder.DropIndex(
                name: "IX_HotelNumbers_NumberTypeId",
                table: "HotelNumbers");

            migrationBuilder.DropColumn(
                name: "NumberStatusId",
                table: "HotelNumbers");

            migrationBuilder.DropColumn(
                name: "NumberTypeId",
                table: "HotelNumbers");
        }
    }
}
