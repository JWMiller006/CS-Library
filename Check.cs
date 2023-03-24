using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMDLibrary
{
    /// <summary>
    /// Contains Basic Functions that are found in other languages that I liked
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Checks if the element is listed in the input list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ele">The value to search for</param>
        /// <param name="values">The list of values to search through</param>
        /// <returns>Returns a boolean; If ele is in values, returns true, else returns false</returns>
        public static bool IsIn<T>(T ele, List<T> values)
        {
            foreach (T value in values)
            {
                if (ele.Equals(value)) return true;
            }
            return false;
        }


        /// <summary>
        /// Checks if the element is listed in the input array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ele">The value to search for</param>
        /// <param name="values">The array of values to search through</param>
        /// <returns>Returns a boolean; If ele is in values, returns true, else returns false</returns>
        public static bool IsIn<T>(T ele, T[] values) 
        {
            foreach (T value in values)
            {
                if (value.Equals(ele))
                {
                    return true;
                }
            }
            return false;
        }
    }


}
