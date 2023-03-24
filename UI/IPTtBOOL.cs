using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLibrary.UI
{
    public class StrtoTF
    {
        public static bool StrToTF(string InputIn)
        {
            bool check = true;
            var yea = new List<string> { "yes", "yeah", "true", "y", "e", "s", "yea", "ok", "okay", "duh", "", " "};
            var ney = new List<string> { "no", "not", "false", "n", "o", "nah", "nope", "not today", "what do you think?", "exit", "e" };
            bool match = false;
            while (check)
            {
                InputIn = InputIn.ToLower();
                for (var i = 0; i < yea.Count(); i++)
                {
                    if (InputIn == yea[i])
                    {
                        return true;
                    }
                    else
                    {
                        match = false;
                    }
                }
                if (match == false)
                {
                    for (var i = 0; i < ney.Count(); i++)
                    {
                        if (InputIn == ney[i])
                        {
                            return false;
                        }
                    }
                }
                else 
                {
                    match = false;
                }
                if (match == false) 
                {
                    Console.WriteLine("Your input was not understood" +
                        " and now you can try again...");
                    InputIn = Console.ReadLine();
                }
                check = match;
            }
            return false;
        }
    }
}
