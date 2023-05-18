using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelsSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtableReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_HotelNumbers_HotelNumberId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_HotelNumberId",
                table: "Reservations",
                newName: "IX_Reservations_HotelNumberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_HotelNumbers_HotelNumberId",
                table: "Reservations",
                column: "HotelNumberId",
                principalTable: "HotelNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_HotelNumbers_HotelNumberId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_HotelNumberId",
                table: "Reservation",
                newName: "IX_Reservation_HotelNumberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_HotelNumbers_HotelNumberId",
                table: "Reservation",
                column: "HotelNumberId",
                principalTable: "HotelNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
