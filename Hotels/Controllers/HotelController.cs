using HotelsSite.Application.Hotels;
using HotelsSite.Application.Hotels.Create;
using HotelsSite.Application.Hotels.Query;
using HotelsSite.Application.Hotels.Read;
using Microsoft.AspNetCore.Mvc;

namespace HotelsSite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly HotelHandler _handler;

        public HotelController(HotelHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<int> Create(CreateHotelRequest request)
        {
            return await _handler.Create(request);
        }

        [HttpGet("{id}")]
        public async Task<ReadHotelResponse> ReadCurrent(int id)
        {
            return await _handler.Read(new ReadHotelRequest(id));
        }

        [HttpGet]
        public async Task<List<QueryHotelResponse>> ReadAll()
        {
            return await _handler.Query(new QueryHotelRequest());
        }
    }
}
