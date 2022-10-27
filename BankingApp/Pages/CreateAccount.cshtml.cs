using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApp
{
    public class CreateAccountModel : PageModel
    {
        [BindProperty]
        public AccountInformation AccountInformation_NewUser { get; set; }

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            //TODO
            //CREATE FORM FIELD GRABBER
            //grab fields from form
            //User NewUser = new User(FirstName, LastName, Pin);

            //ClientDatabaseConnection clientDbConnection = new ClientDatabaseConnection()
            // NewUser = clientDbConnection.InsertNewUser(NewUser);

            //if(NewUser.IsValidUser)
            //  go to Account Home Page (which will say "Hi {firstname} !")
            //          Note: Account Home Page will also have a different nav bar with options
            //                  to deposit, withdraw, and edit account information
            
        }

        public class AccountInformation
        {
            [Required]
            [Display(Name = "First Name:")]
            public String FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name:")]
            public String LastName { get; set; }

            [Required]
            [Display(Name = "Desired Pin:")]
            public String Pin { get; set; }
  
        }
    }
}
