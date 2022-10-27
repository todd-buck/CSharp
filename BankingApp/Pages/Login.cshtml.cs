using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credentials UserCredentials { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            //TODO
            //CREATE FORM FIELD GRABBER
            //grab fields from form
            //User PotentialNewUser = new User(CardNum, Pin);

            //ClientDatabaseConnection clientDbConnection = new ClientDatabaseConnection()
            // NewUser = clientDbConnection.ValidateUser(PotentialNewUser);

            //if(NewUser.IsValidUser)
            //  go to Account Home Page (which will say "Hi {firstname} !") and display balance
            //          Note: Account Home Page will also have a different nav bar with options
            //                  to deposit, withdraw, and edit account information
            //else
            //  display error message, clear fields

        }

        public class Credentials
        {
            [Required]
            [Display(Name = "Credit Card #:")]
            public String CardNum { get; set; }

            [Required]
            [Display(Name = "Pin:")]
            public String Pin { get; set; }

        }
    }
}
