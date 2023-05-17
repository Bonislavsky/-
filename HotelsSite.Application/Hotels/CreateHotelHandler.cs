using HotelsSite.Infrastructure.Database;
using HotelsSite.Infrastructure.Error;
using MediatR;
using System.Net;

namespace HotelsSite.Application.Hotels
{
    public class CreateHotelHandler : IRequestHandler<CreateHotelRequest, int>
    {
        private readonly HotelsSiteContext _context;

        public CreateHotelHandler(HotelsSiteContext context)
        {
            _context = context;
        }

        public Task<int> Handle(CreateHotelRequest request, CancellationToken cancellationToken)
        {
            throw new RestException(HttpStatusCode.NotFound,
                    new { InvoiceId = $"the user has no credit note with this id:{request.Name}" });
        }
    }
}
