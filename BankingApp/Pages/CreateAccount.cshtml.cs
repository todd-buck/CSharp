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
