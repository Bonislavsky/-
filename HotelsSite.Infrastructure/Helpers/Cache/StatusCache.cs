using HotelsSite.Domain.Enums;
using HotelsSite.Infrastructure.Database;

namespace HotelsSite.Infrastructure.Helpers.Cache
{
    public class StatusCache : IStatusCache
    {
        private readonly Dictionary<string, NumberStatus> _numberStatus;
        private readonly Dictionary<string, NumberType> _numberType;

        public StatusCache(HotelsSiteContext context)
        {
            _numberStatus = context.NumberStatuses.ToDictionary(s => s.Name);
            _numberType = context.NumberTypes.ToDictionary(s => s.Name);
        }

        public NumberStatus? GetNumberStatusOrNull(string statusName)
        {
            if (_numberStatus.TryGetValue(statusName, out NumberStatus status))
            {
                return status;
            }

            return null;
        }

        public NumberType? GetNumberTypeOrNull(string statusName)
        {
            if (_numberType.TryGetValue(statusName, out NumberType status))
            {
                return status;
            }

            return null;
        }
    }
}
