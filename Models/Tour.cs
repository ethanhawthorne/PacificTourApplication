namespace My_Pacific_Tour_App.Models
{
    //This represents the class "Tour" that holds the properties i will be manipulating throughout the project

    public class Tour
    {
        public Guid TourId { get; set; }
        public string Name { get; set; }
        public int DurationInDays { get; set; }
        public decimal Cost { get; set; }
        public int AvailableSpaces { get; set; }
    }
}
