using HotelsSite.Application.HotelNumbers.Query;
using HotelsSite.Domain;

namespace HotelsSite.Application.Hotels.Read
{
    public class ReadHotelResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public IEnumerable<QueryHotelNumberResponse> HotelNumber { get; set; }

        public ReadHotelResponse(Hotel hostel)
        {
            Id= hostel.Id;
            Name= hostel.Name;
            Description= hostel.Description;
            Adress = hostel.Adress;
            HotelNumber = hostel.HotelNumbers.Select(hn => new QueryHotelNumberResponse(hn));
        }
    }
}
