using HotelsSite.Domain;
using HotelsSite.Infrastructure.Database;

namespace HotelsSite.Application.Hotels
{
    public class HotelHandler
    {
        private readonly HotelsSiteContext _context;

        public HotelHandler(HotelsSiteContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CreateHotelRequest request, CancellationToken cancellationToken = default)
        {
            var hotel = new Hotel()
            {
                Name = request.Name,
                Adress = request.Adress,
                Description = request.Description,  
            };

            await _context.AddAsync(hotel, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return hotel.Id;
        }
    }
}
