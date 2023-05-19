using HotelsSite.Application.Reservations.Create;
using HotelsSite.Application.Reservations.DateUpdater;
using HotelsSite.Application.Reservations.Delete;
using HotelsSite.Application.Reservations.Read;
using HotelsSite.Domain;
using HotelsSite.Infrastructure.Database;
using HotelsSite.Infrastructure.Error;
using HotelsSite.Infrastructure.Helpers.Cache;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotelsSite.Application.Reservations
{
    public class ReservationHandler
    {
        private readonly HotelsSiteContext _context;
        private readonly IStatusCache _statusCache;

        public ReservationHandler(HotelsSiteContext context, IStatusCache statusCache)
        {
            _context = context;
            _statusCache = statusCache;
        }

        public async Task<int> Create(CreateReservationRequest request, CancellationToken cancellationToken = default)
        {
            var hotelNumer = await _context.HotelNumbers
                .Include(hn => hn.NumberStatus)
                .SingleOrDefaultAsync(x => x.Id == request.HotelNumberId, cancellationToken)
                ?? throw new RestException(HttpStatusCode.NotFound,
                    new { HotelId = $"Hotel number dy id:{request.HotelNumberId} not found" });

            if (!hotelNumer.NumberStatus.Name.Equals("available"))
            {
                throw new RestException(HttpStatusCode.BadRequest,
                    new { HotelId = $"Hotel number dy id:{request.HotelNumberId} this number is not free" });
            }

            var newReservation = new Reservation()
            {
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                GuestName = request.GuestName,
                HotelNumberId = request.HotelNumberId,
            };

            hotelNumer.NumberStatusId = _statusCache.GetNumberStatusOrNull("reserved").Id;
            _context.Entry(hotelNumer).Property(x => x.NumberStatusId).IsModified = true;

            await _context.Reservations.AddAsync(newReservation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newReservation.Id;
        }

        public async Task<ReadReservationResponse> DateUpdate(ReservationDateUpdaterRequest request, CancellationToken cancellationToken = default)
        {
            var reservation = _context.Reservations.SingleOrDefault(re => re.Id == request.Id)??
                throw new RestException(HttpStatusCode.NotFound,
                    new { HotelId = $"Reservation dy id:{request.Id} not found" });

            reservation.CheckOutDate = request.CheckOutDate;
            reservation.CheckInDate = request.CheckInDate;

            _context.Reservations.Attach(reservation).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);

            return new ReadReservationResponse(reservation);
        }

        public async Task<bool> Delete(DeleteReservationRequest request, CancellationToken cancellationToken = default)
        {
            var reservation = _context.Reservations
                .Include(x => x.HotelNumber)
                .SingleOrDefault(re => re.Id == request.Id) ??
                throw new RestException(HttpStatusCode.NotFound,
                    new { HotelId = $"Reservation dy id:{request.Id} not found" });

            reservation.HotelNumber.NumberStatusId = _statusCache.GetNumberStatusOrNull("available").Id;
            _context.Entry(reservation.HotelNumber).Property(x => x.NumberStatusId).IsModified = true;

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
