namespace HotelsSite.Application.Hotels.Query
{
    public class QueryHotelResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public int AvailableRooms { get; set; }
        public int ReservedRooms { get; set; }
    }
}
