namespace HotelsSite.Domain
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public string GuestName { get; set; }

        public int HotelNumberId { get; set; }
        public HotelNumber HotelNumber { get; set; }
    }
}
