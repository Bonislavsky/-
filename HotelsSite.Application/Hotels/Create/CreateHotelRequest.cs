using MediatR;

namespace HotelsSite.Application.Hotels.Create
{
    public class CreateHotelRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
    }
}
