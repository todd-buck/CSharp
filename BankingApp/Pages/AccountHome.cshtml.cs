using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApp.Pages
{
    public class AccountHomeModel : PageModel
    {
        public User UserSession { get; set; }

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
    }
}
