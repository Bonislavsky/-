namespace HotelsSite.Domain.Enums
{
    public class NumberStatus
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public ICollection<HotelNumber> HotelNumbers { get; set; } = new HashSet<HotelNumber>();
    }
}
