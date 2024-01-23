namespace My_Pacific_Tour_App.Models
{
    //This represents the class "HotelBooking" that holds the properties i will be manipulating throughout the project

    public class HotelBooking
    {
        public Guid HotelBookingId { get; set; }
        public string UserId { get; set; }
        public Guid HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsCancelled { get; set; } = false;
        public bool IsPaid { get; set; } = false;

        //This is for navigation
        public Hotel Hotel { get; set; }
        public User User { get; set; }
    }
}
