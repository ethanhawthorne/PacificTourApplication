using My_Pacific_Tour_App.Models;
using My_Pacific_Tour_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace My_Pacific_Tour_App.Pages
{
    public class ViewBookingsModel : PageModel
    {
        //bound to the page
        [BindProperty]
        public ViewBookingsTableModel ViewBookingsTable { get; set; }

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        //represents the data to be displayed on the page
        public class ViewBookingsTableModel
        {
            //the lists of hotels and the tours
            public List<HotelBooking> HotelBookingsList { get; set; } = new List<HotelBooking>();
            public List<TourBooking> TourBookingsList { get; set; } = new List<TourBooking>();

        }

        public ViewBookingsModel(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            //initialize the correct property
            ViewBookingsTable = new ViewBookingsTableModel();
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            //gets the correct user
            var CurrentUser = await _userManager.GetUserAsync(User);
            //gets the relevent bookings of the user
            var hotelBookingsList = await _dbContext.HotelBookings
                .Where(hb => hb.UserId.Equals(CurrentUser.Id) && hb.IsCancelled == false)
                .Include(hb => hb.Hotel)
                .ToListAsync();
            //populate the list with the relevant data
            ViewBookingsTable.HotelBookingsList = hotelBookingsList;
            //gets tour bookings from the current user
            var tourBookingsList = await _dbContext.TourBookings
                .Where(tb => tb.UserId.Equals(CurrentUser.Id) && tb.IsCancelled == false)
                .Include(tb => tb.Tour)
                .ToListAsync();
             //populate tours booked by the user
            ViewBookingsTable.TourBookingsList = tourBookingsList;

            return Page();
        }

        public async Task<IActionResult> OnPostHotelTableAsync(string command, string returnUrl = null)
        {
            if (command == "Cancel")
            {
                //retrieves the relevant hotel booking
                var HotelBookingId = new Guid(Request.Form["hotelBookingId"]);
                //gets the correct hotel booking
                var hotelBooking = await _dbContext.HotelBookings
                    .Where(hb => hb.HotelBookingId == HotelBookingId)
                    .FirstOrDefaultAsync();
                //chnage the hotel to be seen as cancelled
                hotelBooking.IsCancelled = true;
                //saves changes as seen
                await _dbContext.SaveChangesAsync();
                //redirects to the new viewbookings page
                return RedirectToPage("/ViewBookings");
            }
            //if the button pressed is not cancel then it must be edit so it takes the user to the edit page
            else
            {
                return RedirectToPage("/EditHotelBooking", new 
                {
                    hotelBookingId = Request.Form["hotelBookingId"]
                });
            }
        }
        //similar to the above but changed in necessary places to cater for tours
        public async Task<IActionResult> OnPostTourTableAsync(string command, string returnUrl = null)
        {
            if (command == "Cancel")
            {
                var TourBookingId = new Guid(Request.Form["tourBookingId"]);

                var tourBooking = await _dbContext.TourBookings
                    .Where(tb => tb.TourBookingId == TourBookingId)
                    .FirstOrDefaultAsync();

                tourBooking.IsCancelled = true;

                await _dbContext.SaveChangesAsync();

                return RedirectToPage("/ViewBookings");
            }
            else
            {
                return RedirectToPage("/EditTourBooking", new
                {
                    tourBookingId = Request.Form["tourBookingId"]
                });
            }
        }


    }
}
