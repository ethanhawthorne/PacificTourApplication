namespace My_Pacific_Tour_App.Models
{
    //This represents the class "TourBookings" that holds the properties i will be manipulating throughout the project

    public class TourBooking
    {
        public Guid TourBookingId { get; set; }
        public string UserId { get; set; }
        public Guid TourId { get; set; }
        public DateTime TourStartDate { get; set; }
        public DateTime TourEndDate { get; set; }
        public bool IsCancelled { get; set; } = false;
        public bool IsPaid { get; set; } = false;

        //THis is for Navigation 
        public Tour Tour { get; set; }
        public User User { get; set; }
    }
}
