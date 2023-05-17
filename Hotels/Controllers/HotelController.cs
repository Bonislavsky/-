using HotelsSite.Application.Hotels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelsSite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly HotelHandler _handler;

        public HotelController(IMediator mediator, HotelHandler handler)
        {
            _mediator = mediator;
            _handler = handler;
        }

        [HttpPost]
        public async Task<int> Create(CreateHotelRequest request)
        {
            return await _handler.Create(request);
        }
    }
}
