using My_Pacific_Tour_App.Models;
using My_Pacific_Tour_App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace My_Pacific_Tour_App.Pages
{//page model for payments
    public class PaymentModel : PageModel
    {
        //represents the binding of the razpr page
        [BindProperty]
        public PaymentFormModel PaymentForm { get; set; }

        //Context and user manager injected
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        //constructor initializes the payment with the database context and user manager
        public PaymentModel(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            PaymentForm = new PaymentFormModel();
            _dbContext = dbContext;
            _userManager = userManager;
        }
        //defining all the card details with some validation
        public class PaymentFormModel
        {
            [Required(ErrorMessage = "Please enter name on card")]
            [DataType(DataType.Text)]
            [Display(Name = "Card name")]
            public string CardName { get; set; }

            [Required(ErrorMessage = "Please enter card number")]
            [DataType(DataType.Text)]
            [Display(Name = "Card name")]
            [RegularExpression(@"^\d{17}$", ErrorMessage = "Invalid credit card number.")]
            public string CardNumber { get; set; }

            [Required(ErrorMessage = "Enter billing address")]
            [DataType(DataType.Text)]
            [Display(Name = "Billing address")]
            public string BillingAddress { get; set; }

            [Required(ErrorMessage = "Input card expiry date")]
            [DataType(DataType.Date)]
            [Display(Name = "Expiry date")]
            public DateOnly CardExpiryDate { get; set; }

            [Required(ErrorMessage = "Enter CVC number")]
            [Display(Name = "CVC number")]
            [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Invalid CVC number")]
            public string CvcNumber { get; set; }

            //error maessage to store payment error
            public string ErrorMessage { get; set; }
        }
        //
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //get the booking ddetails based on this query
            var BookingId = new Guid(Request.Query["bookingId"]);
            var BookingType = Request.Query["bookingType"];

            //mark the hotel as paid
            if (BookingType == "hotel")
            {
                //get the hotel booking from the database
                HotelBooking hotelBooking = await _dbContext.HotelBookings.FindAsync(BookingId);
                
                //mark as paid
                hotelBooking.IsPaid = true;
                await _dbContext.SaveChangesAsync();
                
                //bring user back to view bookings page
                return RedirectToPage("/ViewBookings", new
                { 
                    successMessage = "You're Booked!"
                });
            }
            //similar to the above but catered for the tour option
            else if (BookingType == "tour")
            {
                TourBooking tourBooking = await _dbContext.TourBookings.FindAsync(BookingId);

                tourBooking.IsPaid = true;
                await _dbContext.SaveChangesAsync();

                return RedirectToPage("/ViewBookings", new
                {
                    successMessage = "Fully Booked!!!"
                });
            }
            //just throws and error if its neither hotel or tour
            else
            {
                PaymentForm.ErrorMessage = null;

                PaymentForm.ErrorMessage = "Payment error. Please re-attempted payment";

                return Page();
            }
        }
    }
}
