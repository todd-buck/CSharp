using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credentials UserCredentials { get; set; }

        public bool InvalidCredentials = false;

        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("InvalidCredentials") != null && HttpContext.Session.GetInt32("InvalidCredentials") == 1)
            {
                InvalidCredentials = true;
                HttpContext.Session.SetInt32("InvalidCredentials", 0);
            }
        }

        public void OnPost()
        {
            //Validates User
            User PotentialUser = new User(Request.Form["UserCredentials.CardNum"], Request.Form["UserCredentials.Pin"]);
            ClientDatabaseConnection clientDbConnection = new ClientDatabaseConnection();
            PotentialUser = clientDbConnection.ValidateUser(PotentialUser);

            if (PotentialUser.IsValidUser)
            {
                //send client data to session buffer (to be retrived by Account Home Model)
                HttpContext.Session.SetString("FirstName", PotentialUser.FirstName);
                HttpContext.Session.SetString("LastName", PotentialUser.LastName);
                HttpContext.Session.SetString("CardNum", PotentialUser.CardNum);
                HttpContext.Session.SetString("Pin", PotentialUser.Pin);
                HttpContext.Session.SetString("Balance", PotentialUser.Balance);
                HttpContext.Session.SetInt32("IsValidUser", 1);

                //Sends UI to Account Home page
                Response.Redirect("AccountHome");
                
            }
            else
            {
                HttpContext.Session.SetInt32("InvalidCredentials", 1);
                ////TODO: add error message on incorrect login
                ////Incorrect CardNum/Pin, redirects to login page
                Console.WriteLine("Invalid CardNum/Pin");
                Response.Redirect("Login");
            }

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
