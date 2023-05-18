namespace HotelsSite.Application.Hotels.Read
{
    public class ReadHotelRequest
    {
        public int HostelId { get; set; }

        public ReadHotelRequest(int hostelId)
        {
            HostelId = hostelId;
        }
    }
}
