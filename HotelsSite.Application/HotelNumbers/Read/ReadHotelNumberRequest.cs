namespace HotelsSite.Application.HotelNumbers.Read
{
    public class ReadHotelNumberRequest
    {
        public int HotelNumberId { get; set; }

        public ReadHotelNumberRequest(int hotelNumberId)
        {
            HotelNumberId = hotelNumberId;
        }
    }
}
