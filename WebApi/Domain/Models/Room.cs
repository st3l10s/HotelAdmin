namespace WebApi.Domain.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int Floor { get; set; }
        public int Door { get; set; }
        public bool Enabled { get; set; }

        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }

        public int TypeID { get; set; }
        public RoomType Type { get; set; }
    }
}