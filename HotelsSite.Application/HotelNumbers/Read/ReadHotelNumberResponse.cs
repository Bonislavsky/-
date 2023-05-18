using HotelsSite.Application.Reservations.Read;
using HotelsSite.Domain;

namespace HotelsSite.Application.HotelNumbers.Read
{
    public class ReadHotelNumberResponse
    {
        public int Id { get; set; }

        public string NumberStatus { get; set; }
        public string NumberType { get; set; }

        public int HotelId { get; set; }

        public ReadReservationResponse? Reservation { get; set; }

        public ReadHotelNumberResponse(HotelNumber hotelNumber)
        {
            Id = hotelNumber.Id;
            NumberStatus = hotelNumber.NumberStatus.Name;
            NumberType = hotelNumber.NumberType.Name;
            HotelId = hotelNumber.HotelId;
            Reservation = hotelNumber.Reservation is null ? null : new ReadReservationResponse(hotelNumber.Reservation);
        }
    }
}
