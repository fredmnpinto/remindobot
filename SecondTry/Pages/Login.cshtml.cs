using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondTry.Pages
{
    public class Login : PageModel
    {
        public string Message;
        private List<string> _prohibitedStrings;
        private List<char> _specialChar;
        public void OnGet()
        {
            string[] prohibited = {"or", "and"};
            char[] specialCharArray = { ' ', '\t', '\n', ',', ';', '|', '\\', ',' };

            _specialChar = new List<char>(specialCharArray);
            _prohibitedStrings = new List<string>(prohibited);
            Message = $"Current time at server is: {DateTime.Now}";
        }

        public void OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            Console.WriteLine(ValidateUsername(username));
            Console.WriteLine(ValidatePassword(password));
            

        }

        private bool ValidatePassword(string pass)
        {
            string lowPass = pass.ToLower();
            foreach (string s in _prohibitedStrings)
                if (lowPass.Contains(s))
                    return false;
            return true;
        }
        private bool ValidateUsername(string user)
        {
            string lowStr = user.ToLower();
            foreach (string s in _prohibitedStrings)
            {
                if (lowStr.Contains(s))
                    return false;
            }

            foreach (char c in _specialChar)
            {
                if (lowStr.Contains(c))
                    return false;
            }

            return true;
        }
    }
}