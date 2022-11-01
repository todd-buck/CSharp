using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankingApp.Pages;
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
            //implement check to ensure that user inpus are valid (no spaces in first name, last name + pin is only numbers

            //preparing user input (eliminating all spaces from input)
            string UserInput_FirstName = Request.Form["UserCredentials.FirstName"];
            if (UserInput_FirstName.Contains(" ")) UserInput_FirstName.Replace(" ", "");

            string UserInput_LastName = Request.Form["UserCredentials.LastName"];
            if (UserInput_LastName.Contains(" ")) UserInput_LastName.Replace(" ", "");

            string UserInput_Pin = Request.Form["UserCredentials.Pin"];
            if (UserInput_Pin.Contains(" ")) UserInput_Pin.Replace(" ", "");

            User NewUser = new User(Request.Form["AccountInformation_NewUser.FirstName"], Request.Form["AccountInformation_NewUser.LastName"], Request.Form["AccountInformation_NewUser.Pin"]);
            ClientDatabaseConnection clientDbConnection = new ClientDatabaseConnection();
            NewUser = clientDbConnection.InsertNewUser(NewUser);

            AccountHomeModel AccountHome = new AccountHomeModel();

            HttpContext.Session.SetString("FirstName", NewUser.FirstName);
            HttpContext.Session.SetString("LastName", NewUser.LastName);
            HttpContext.Session.SetString("CardNum", NewUser.CardNum);
            HttpContext.Session.SetString("Pin", NewUser.Pin);
            HttpContext.Session.SetString("Balance", NewUser.Balance);
            HttpContext.Session.SetInt32("IsValidUser", 1);

            Response.Redirect("AccountHome");
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
