using HotelsSite.Domain;

namespace HotelsSite.Application.Reservations.Read
{
    public class ReadReservationResponse
    {
        public int Id { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string GuestName { get; set; }
        public int HotelNumberId { get; set; }

        public ReadReservationResponse(Reservation reservation)
        {
            Id = reservation.Id;
            CheckInDate = reservation.CheckInDate;
            CheckOutDate = reservation.CheckOutDate;

            GuestName = reservation.GuestName;
            HotelNumberId = reservation.HotelNumberId;
        }
    }
}
