namespace My_Pacific_Tour_App.Models
{
    //This represents the class "HotelAvailability" that holds the properties i will be manipulating throughout the project

    public class HotelAvailability
    {
        public Guid HotelAvailabilityId { get; set; }
        public Guid HotelId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        //This is for navigation
        public Hotel Hotel { get; set; }
    }
}
