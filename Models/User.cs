using Microsoft.AspNetCore.Identity;

namespace My_Pacific_Tour_App.Models
{
    //This represents the class "User" that holds the properties i will be manipulating throughout the project

    public class User : IdentityUser
    {
        public String FirstName { get; set; } = "";
        public String LastName { get; set; } = "";
        public String Address { get; set; } = "";
        public String PassportNumber { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
