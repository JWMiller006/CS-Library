using NPOI.SS.Formula.PTG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLibrary.Convert.Strings
{
    /// <summary>
    /// This is a class of the lists used to determine things as true or false, change wisely
    /// </summary>
    public class BoolLists
    {
        /// <summary>
        /// True strings 
        /// </summary>
        public List<string> yea = new() { "yes", "yeah", "true", "y", "e", "s", "yea", "ok", "okay", "duh", "", " " };
        

        
        /// <summary>
        /// False strings 
        /// </summary>
        public List<string> ney = new() { "no", "not", "false", "n", "o", "nah", "nope", "not today", "what do you think?", "exit", "e" };
    }

    /// <summary>
    /// Currently the main algorithm for converting user input to boolean
    /// To call basic use FullStrBool.GetBool
    /// </summary>
    public class FullStrBool
    {
        
        /// <summary>
        /// Takes a user input and converts it to a boolean 
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>The converted boolean</returns>
        public static bool GetBool(string input) 
        {
            bool check = true;
            BoolLists bl = new BoolLists();

            // Strings that are considered true 
            var yea = bl.yea;
            
            // Strings that are considered false
            List<string> ney = bl.ney;
            while (check)
            {
                input = input.ToLower();
                for (var i = 0; i < yea.Count(); i++)
                {
                    if (input == yea[i])
                    {
                        return true;
                    }
                }
                for (var i = 0; i < ney.Count(); i++)
                {
                    if (input == ney[i])
                    {
                        return false;
                    }
                }
                Console.WriteLine("Your input was not understood, try again...");
                input = Console.ReadLine();
            }
                return false;
        }

        /// <summary>
        /// Similar to TryParse, but instead of returning if whether it can be parsed, but what it can be parsed to
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns></returns>
        public static bool TryBool(string input)
        {
            BoolLists bl = new();
            List<string> tr = bl.yea;
            List<string> fa = bl.ney;
            input = input.ToLower();
            for (var i = 0; i < tr.Count; i++)
            {
                if (input == tr[i])
                {
                    return true;
                }
            }
            for (var i = 0; i < fa.Count(); i++)
            {
                if (input == fa[i])
                {
                    return false;
                }
            }
            return false;
        }
    }
}
