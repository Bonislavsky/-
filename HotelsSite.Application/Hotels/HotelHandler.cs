using HotelsSite.Application.Hotels.Create;
using HotelsSite.Application.Hotels.Query;
using HotelsSite.Application.Hotels.Read;
using HotelsSite.Domain;
using HotelsSite.Infrastructure.Database;
using HotelsSite.Infrastructure.Error;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

            await _context.Hotels.AddAsync(hotel, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return hotel.Id;
        }

        public async Task<ReadHotelResponse> Read(ReadHotelRequest request, CancellationToken cancellationToken = default)
        {
            var hotel = await _context.Hotels
                .AsNoTracking()
                .Include(hotel => hotel.HotelNumbers)
                    .ThenInclude(hn => hn.NumberStatus)
                .Include(hotel => hotel.HotelNumbers)
                    .ThenInclude(hn => hn.NumberType)
                .SingleOrDefaultAsync(hotel => hotel.Id == request.HostelId) ??
                throw new RestException(HttpStatusCode.NotFound, 
                    new { HotelId = $"hotel by id:{request.HostelId} not found" });

            return new ReadHotelResponse(hotel);
        }

        public async Task<List<QueryHotelResponse>> Query(QueryHotelRequest request, CancellationToken cancellationToken = default)
        {
            return await _context.Hotels
                .AsNoTracking()
                .Include(hotel => hotel.HotelNumbers)
                    .ThenInclude(hn => hn.NumberStatus)
                .Select(hotel => new QueryHotelResponse
                {
                    Id = hotel.Id,
                    Description = hotel.Description,
                    Adress = hotel.Adress,
                    AvailableRooms = hotel.HotelNumbers.Count(hn => hn.NumberStatus.Name.Equals("available")),
                    ReservedRooms = hotel.HotelNumbers.Count(hn => hn.NumberStatus.Name.Equals("reserved")),
                }).ToListAsync();
        }
    }
}
    