using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApp.Pages
{
    public class DepositModel : PageModel
    {
        public User UserSession { get; set; }

        public string Amount_To_Deposit;

        public void OnGet()
        {
            UserSession = new User(
            HttpContext.Session.GetString("FirstName"),
            HttpContext.Session.GetString("LastName"),
            HttpContext.Session.GetString("CardNum"),
            HttpContext.Session.GetString("Pin"),
            HttpContext.Session.GetString("Balance"),
            HttpContext.Session.GetInt32("IsValidUser")
            );

        }

        public void OnPost()
        {
            //TODO
            // collect Amount_To_Deposit from form
            // convert Amount_To_Deposit to double
            // convert UserSession.Balance to double
            // add Amount_To_Deposit and UserSession.Balance, store as string in UserSession.Balance
            // push new UserSession data to Session buffer
            // redirect back to Deposit, should display updated balance

            //Notes: Display success message i.e. "Successfully deposited $x!" ?
        }
    }
}
