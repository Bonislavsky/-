namespace HotelsSite.Application.Reservations.Create
{
    public class CreateReservationRequest
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string GuestName { get; set; }

        public int HotelNumberId { get; set; }
    }
}
