using MediatR;

namespace HotelsSite.Application.Hotels
{
    public class CreateHotelRequest : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
    }
}
