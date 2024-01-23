using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace My_Pacific_Tour_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //constructor that initializes the model with logger
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        //empty handler
        public void OnGet()
        {

        }
    }
}
