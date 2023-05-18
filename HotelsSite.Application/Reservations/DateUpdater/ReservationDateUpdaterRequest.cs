namespace HotelsSite.Application.Reservations.DateUpdater
{
    public class ReservationDateUpdaterRequest
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
