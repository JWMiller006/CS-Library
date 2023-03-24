using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Personal Lirbaries 
using CMDLibrary.Convert.Files;
using CMDLibrary.Security.AdminLogin.Models;

namespace CMDLibrary.Security.AdminLogin
{
    public class Login
    {
        public static LoginModel CheckLogin(string username, string password, string rootPath) 
        {
            LoginModel Output = new LoginModel();
            var Usernames = new List<string> { };
            var Passwords= new List<string> { };
            var AdminLevel = new List<string> { };
            var UserFiles = new List<string> { };
            var Managers = new List<string> { };
            Usernames.AddRange(File_List.FileRead(rootPath + "Sec\\UName.txt"));
            Passwords.AddRange(File_List.FileRead(rootPath + "Sec\\PWord.txt"));
            AdminLevel.AddRange(File_List.FileRead(rootPath + "Sec\\ALevel.txt"));
            UserFiles.AddRange(File_List.FileRead(rootPath + "Sec\\UserFiles.txt"));
            Managers.AddRange(File_List.FileRead(rootPath + "Sec\\Manager.txt"));
            int count = 0;
            bool saveA = false; 
            Output.LoggedIn = false;
            foreach (string line in Usernames) 
            {
                if (line == username) 
                {
                    if (Passwords[count] == password) 
                    {
                        if (AdminLevel[count] == "true")
                        {
                            saveA = true;
                        }
                        Output.LoggedIn = true;
                        Output.UserName = username;
                        Output.Password = password;
                        Output.SecurityLevel = saveA;
                        Output.UserHistory = UserFiles[count];
                        Output.Manager = Managers[count];
                    }
                }
                count++;
            }
            Console.Clear();
            return Output;
        }
    }
}
