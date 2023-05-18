using HotelsSite.Domain.Enums;

namespace HotelsSite.Infrastructure.Helpers.Cache
{
    public interface IStatusCache
    {
        NumberStatus? GetNumberStatusOrNull(string statusName);
        NumberType? GetNumberTypeOrNull(string statusName);
    }
}
