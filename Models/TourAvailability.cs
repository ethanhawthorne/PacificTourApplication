namespace My_Pacific_Tour_App.Models
{
    //This represents the class "TourAvailability" that holds the properties i will be manipulating throughout the project

    public class TourAvailability
    {
        public Guid TourAvailabilityId { get; set; }
        public Guid TourId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }

        //This is for Navigation 
        public Tour Tour { get; set; }
    }
}
