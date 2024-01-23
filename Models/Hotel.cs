namespace My_Pacific_Tour_App.Models
{
    //This represents the class "Hotel" that holds the properties i will be manipulating throughout the project
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public string RoomType { get; set; }
        public decimal Cost { get; set; }
        public int AvailableSpaces { get; set; }
    }
}
