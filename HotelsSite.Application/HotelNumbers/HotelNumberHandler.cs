using HotelsSite.Application.HotelNumbers.Create;
using HotelsSite.Application.HotelNumbers.Query;
using HotelsSite.Application.HotelNumbers.Read;
using HotelsSite.Application.Hotels.Read;
using HotelsSite.Domain;
using HotelsSite.Infrastructure.Database;
using HotelsSite.Infrastructure.Error;
using HotelsSite.Infrastructure.Helpers.Cache;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotelsSite.Application.HotelNumbers
{
    public class HotelNumberHandler
    {
        private readonly HotelsSiteContext _context; 
        private readonly IStatusCache _statusCache;

        public HotelNumberHandler(HotelsSiteContext context, IStatusCache statusCache)
        {
            _context = context;
            _statusCache = statusCache;
        }

        public async Task<int> Create(CreateHotelNumberHandler request, CancellationToken cancellationToken = default)
        {
            if(await _context.Hotels.AnyAsync(x => x.Id == request.HotelId, cancellationToken))
            {
                throw new RestException(HttpStatusCode.NotFound,
                    new { HotelId = $"Hotel dy id:{request.HotelId} not found" });
            }

            var numberStatus = _statusCache.GetNumberStatusOrNull(request.NumberStatus)??
               throw new RestException(HttpStatusCode.NotFound,
                    new { Message = $"NumberStatus:{request.NumberStatus} not found" });

            var numberType = _statusCache.GetNumberTypeOrNull(request.NumberType)??
               throw new RestException(HttpStatusCode.NotFound,
                    new { Message = $"NumberType:{request.NumberType} not found" });

            var hotelNumber = new HotelNumber()
            {
                HotelId = request.HotelId,
                NumberStatusId = numberStatus.Id,
                NumberTypeId = numberType.Id,
            };

            await _context.HotelNumbers.AddAsync(hotelNumber, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return hotelNumber.Id;
        }

        public async Task<ReadHotelNumberResponse> Read(ReadHotelNumberRequest request, CancellationToken cancellationToken = default)
        {
            var hotelNumber = await _context.HotelNumbers
                .AsNoTracking()
                .Include(hn => hn.NumberStatus)
                .Include(hn => hn.NumberType)
                .Include(hn => hn.Reservation)
                .SingleOrDefaultAsync(x =>x.Id == request.HotelNumberId ,cancellationToken);

            return new ReadHotelNumberResponse(hotelNumber);
        }

        public async Task<List<QueryHotelNumberResponse>> Query(QueryHotelNumberRequest request, CancellationToken cancellationToken = default)
        {
            return await _context.HotelNumbers
                .AsNoTracking()
                .Include(hn => hn.NumberStatus)
                .Include(hn => hn.NumberType)
                .Select(hn => new QueryHotelNumberResponse(hn))
                .ToListAsync();
        }
    }
}
