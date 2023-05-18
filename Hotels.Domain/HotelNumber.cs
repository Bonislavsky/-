using HotelsSite.Domain.Enums;

namespace HotelsSite.Domain
{
    public class HotelNumber
    {
        public int Id { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public short NumberStatusId { get; set; }
        public NumberStatus NumberStatus { get; set; }

        public short NumberTypeId { get; set; }
        public NumberType NumberType { get; set; }

        public Reservation Reservation { get; set; }
    }
}
