
//#nullable disable
using My_Pacific_Tour_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace My_Pacific_Tour_App.Areas.Identity.Pages.Account
{
    //model is declared
    public class LogoutModel : PageModel
    {
        //mostly given through scaffolding
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        //constructor for the log out model class
        public LogoutModel(SignInManager<User> signInManager, ILogger<LogoutModel> logger)
        {
            //give the provided signinmanager instance to the private field
            _signInManager = signInManager;
            //same as above but for logger
            _logger = logger;
        }

        //triggered when a user wants to log out
        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            //sign out user
            await _signInManager.SignOutAsync();
            //logs the info that the user has been logged out
            _logger.LogInformation("User logged out.");

            //has the return url been provided
            if (returnUrl != null)
            {
                //redirect 
                return LocalRedirect(returnUrl);
            }
            else
            {
 //if noting found just go back to the default page
                return RedirectToPage();
            }
        }
    }
}
