using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApp.Pages
{
    public class EditAccountModel : PageModel
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

        public void OnPost()
        {
            //TODO
            //Push UserSession data (updated with form fields) to Session buffer, route to Account Home Overview

            //UserSession.FirstName = Request.Form["UserSession.FirstName"];
            //UserSession.LastName = Request.Form["UserSession.LastName"];
            //UserSession.Pin = Request.Form["UserSession.Pin"];

            //Response.Redirect("AccountHome"), should pull User data from Session buffer and display updated changes

            
        }
    }
}
