using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApp.Pages
{
    public class WithdrawModel : PageModel
    {
        public User UserSession { get; set; }

        public int Amount_To_Withdraw;

        public bool InvalidWithdraw = false;

        public void OnGet()
        {
            //TODO
            //if Session.GetInt32["InvalidWithdraw"] == 1, set InvalidWithdraw to true

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
            // collect Amount_To_Withdraw from form
            // convert Amount_To_Withdraw to double
            // convert UserSession.Balance to double
            // check that User will be able to withdraw this amount of money
            //      if so, subtract Amount_To_Withdraw from UserSession.Balance, store as string in UserSession.Balance
            // push new UserSession data to Session buffer
            // redirect to Withdraw, which should load with updated balance (to be displayed on page)
        }
    }
}
