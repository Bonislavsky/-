namespace HotelsSite.Domain.Enums
{
    public class NumberType
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<HotelNumber> HotelNumbers { get; set; } = new HashSet<HotelNumber>();
    }
}
