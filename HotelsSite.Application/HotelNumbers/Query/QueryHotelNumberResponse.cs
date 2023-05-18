using HotelsSite.Domain;

namespace HotelsSite.Application.HotelNumbers.Query
{
    public class QueryHotelNumberResponse
    {
        public int Id { get; set; }

        public string NumberStatus { get; set; }
        public string NumberType { get; set; }

        public int HotelId { get; set; }

        public QueryHotelNumberResponse(HotelNumber hotelnumber)
        {
            Id = hotelnumber.Id;
            NumberStatus = hotelnumber.NumberStatus.Name;
            NumberType = hotelnumber.NumberType.Name;
            HotelId = hotelnumber.HotelId;
        }
    }
}
