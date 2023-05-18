using HotelsSite.Application.HotelNumbers;
using HotelsSite.Application.HotelNumbers.Create;
using HotelsSite.Application.HotelNumbers.Query;
using HotelsSite.Application.HotelNumbers.Read;
using HotelsSite.Application.Hotels;
using HotelsSite.Application.Hotels.Create;
using HotelsSite.Application.Hotels.Query;
using HotelsSite.Application.Hotels.Read;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelsSite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelNumberController : ControllerBase
    {
        private readonly HotelNumberHandler _handler;

        public HotelNumberController(HotelNumberHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<int> Create(CreateHotelNumberHandler request)
        {
            return await _handler.Create(request);
        }

        [HttpGet("{id}")]
        public async Task<ReadHotelNumberResponse> ReadCurrent(int id)
        {
            return await _handler.Read(new ReadHotelNumberRequest(id));
        }

        [HttpGet]
        public async Task<List<QueryHotelNumberResponse>> ReadAll()
        {
            return await _handler.Query(new QueryHotelNumberRequest());
        }
    }
}
