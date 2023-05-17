namespace HotelsSite.Domain
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public ICollection<HotelNumber> HotelNumbers { get; set; } = new HashSet<HotelNumber>();
    }
}
