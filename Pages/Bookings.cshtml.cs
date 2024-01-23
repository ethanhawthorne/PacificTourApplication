using My_Pacific_Tour_App.Models;
using My_Pacific_Tour_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace My_Pacific_Tour_App.Pages
{
    public class BookingsModel : PageModel
    {
        //binds the pro search models to the hotel and tour search input
        [BindProperty]
        public HotelSearchModel HotelSearch { get; set; }
        [BindProperty]
        public TourSearchModel TourSearch { get; set; }

        //accessing the database
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        // Constructor method with two parameters dbcontext for database and user manager for user access
        public BookingsModel(ApplicationDbContext dbContext, UserManager<User> userManager)
        { 
            //Prepares the model to handle hotel and tour related search data
            HotelSearch = new HotelSearchModel();
            TourSearch = new TourSearchModel();
            // for database interaction
            _dbContext = dbContext;
            _userManager = userManager;
        }
        //gives validation when a user is inputting data
        public class HotelSearchModel
        {
            [Required(ErrorMessage = "Please select a check-in date")]
            [DataType(DataType.DateTime)]
            [Display(Name = "Check in date")]
            public DateTime CheckInDate { get; set; }

            [Required(ErrorMessage = "Please select a check-out date")]
            [DataType(DataType.DateTime)]
            [Display(Name = "Check out date")]
            public DateTime CheckOutDate { get; set; }

            [Required(ErrorMessage = "Please select a room type")]
            [DataType(DataType.Text)]
            [Display(Name = "Room type")]
            public string RoomType { get; set; } = "Single";
            //list of all choices a user can make
            public List<SelectListItem> RoomTypes { get; set; } = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "single",
                    Text = "Single"
                },
                new SelectListItem
                {
                    Value = "double",
                    Text = "Double"
                },
                new SelectListItem
                {
                    Value = "family suite",
                    Text = "Family Suite"
                }
            };

            public List<Hotel> HotelsList { get; set; } = new List<Hotel>();
        }
        //same idea of validation but for tours
        public class TourSearchModel
        {
            [Required(ErrorMessage = "Please select a tour start date")]
            [DataType(DataType.DateTime)]
            [Display(Name = "Tour start date")]
            public DateTime TourStartDate { get; set; }

            [Required(ErrorMessage = "Please select a tour end date")]
            [DataType(DataType.DateTime)]
            [Display(Name = "Tour end date")]
            public DateTime TourEndDate { get; set; }

            public List<String> AvailableTours { get; set; } = new List<string>();

            public List<Tour> ToursList { get; set; } = new List<Tour>();
        }

        //seaches for relevant hotels
        public async Task<IActionResult> OnPostHotelSearchAsync(string command, string returnUrl = null)
        {
            //checks the model state is valud
            if (!ModelState.IsValid)
            {
                //if not return page to give validation errors
                return Page();
            }
            //make sure the command is search which should alwat be the case with button press
            if (command == "Search")
            {
                //finds hotel with relevant criteria
                var availableHotels = await _dbContext.HotelAvailabilities
                    .Where(ha =>
                        ha.AvailableFrom <= HotelSearch.CheckInDate &&
                        ha.AvailableTo >= HotelSearch.CheckOutDate &&
                        ha.Hotel.RoomType == HotelSearch.RoomType)
                    .Select(ha => ha.Hotel)
                    .Distinct()
                    .ToListAsync();
                //populate the hotel list with relevant hotels
                HotelSearch.HotelsList = availableHotels;
                //returns and displays results
                return Page();
            }
            //This happens when the book button is pressed instead
            else
            {
                //gets the selected hotel
                var SelectedHotelId = new Guid(Request.Form["hotels"]);
                //gets the current user
                var CurrentUser = await _userManager.GetUserAsync(User);
                Hotel SelectedHotel = await _dbContext.Hotels.FindAsync(SelectedHotelId);

                //writes a new booking
                var hotelBooking = new HotelBooking
                {
                    HotelBookingId = new Guid(),
                    HotelId = SelectedHotelId,
                    UserId = CurrentUser.Id,
                    CheckInDate = HotelSearch.CheckInDate,
                    CheckOutDate = HotelSearch.CheckOutDate,
                    Hotel = SelectedHotel,
                    User = CurrentUser
                };

                _dbContext.HotelBookings.Add(hotelBooking);
                await _dbContext.SaveChangesAsync();
                //brings user to the payment page
                return RedirectToPage("/Payment", new
                {
                    bookingId = hotelBooking.HotelBookingId.ToString(),
                    bookingType = "hotel"
                });
            }
        }
        //same as above but for tours
        public async Task<IActionResult> OnPostTourSearchAsync(string command, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //button press is search
            if (command == "Search")
            {
                //finds tours with relevant criteria
                var availableTours = await _dbContext.TourAvailabilities
                .Where(ta =>
                    ta.AvailableFrom <= TourSearch.TourStartDate && 
                    ta.AvailableTo >= TourSearch.TourEndDate)
                .Select(ta => ta.Tour)
                .Distinct()
                .ToListAsync();
                //populate tour list with available tours
                TourSearch.ToursList = availableTours;
                //return the page

                return Page();
            }
            // else the book button is pressed and so this will go through the booking process
            else
            {
                //gets current users and tours
                var SelectedTourId = new Guid(Request.Form["tours"]);
                var CurrentUser = await _userManager.GetUserAsync(User);
                Tour SelectedTour = await _dbContext.Tours.FindAsync(SelectedTourId);

                //writes new booking
                var tourBooking = new TourBooking
                {
                    TourBookingId = new Guid(),
                    TourId = SelectedTourId,
                    UserId = CurrentUser.Id,
                    TourStartDate = TourSearch.TourStartDate,
                    TourEndDate = TourSearch.TourEndDate,
                    Tour = SelectedTour,
                    User = CurrentUser
                };
                //adds to the database
                _dbContext.TourBookings.Add(tourBooking);
                await _dbContext.SaveChangesAsync();
                // takes the user to the payment page
                return RedirectToPage("/Payment", new
                {
                    bookingId = tourBooking.TourBookingId.ToString(),
                    bookingType = "tour"
                });
            }
        }

    }
}
