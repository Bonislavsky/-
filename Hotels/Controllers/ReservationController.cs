using HotelsSite.Application.HotelNumbers;
using HotelsSite.Application.Hotels.Create;
using HotelsSite.Application.Reservations;
using HotelsSite.Application.Reservations.Create;
using HotelsSite.Application.Reservations.DateUpdater;
using HotelsSite.Application.Reservations.Delete;
using HotelsSite.Application.Reservations.Read;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelsSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationHandler _handler;

        public ReservationController(ReservationHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<int> Create(CreateReservationRequest request)
        {
            return await _handler.Create(request);
        }


        [HttpPut]
        public async Task<ReadReservationResponse> UpdateDate(ReservationDateUpdaterRequest request)
        {
            return await _handler.DateUpdate(request);
        }

        [HttpDelete]
        public async Task<bool> CancelReservation(DeleteReservationRequest request)
        {
            return await _handler.Delete(request);
        }
    }
}
