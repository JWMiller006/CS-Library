using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLibrary.Security.AdminLogin.Models
{
    public class LoginModel
    {
        private static string root = "C:\\Program Files (x86)\\Miller Inc \\Console App";
        public bool LoggedIn { get; set; } = false;
        public string UserName { get; set; } = "Guest";
        public string Password { get; set; } = "password";
        public bool SecurityLevel { get; set; } = false;
        public string UserHistory { get; set; } = root + "UserInfo\\Guest.txt";
        public string Manager { get; set; } = "None";
    }
}
