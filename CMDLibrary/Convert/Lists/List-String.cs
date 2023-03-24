// using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLibrary.Convert.Lists
{
    public class List_String
    {
        public static string ListString<T>(List<T> inList, string sepA = "", string sepB = "\n") 
        {
            string Output = "";
            int count = 0;
            foreach (T obj in inList) 
            {
                if (count < inList.Count - 1)
                {
                    Output += obj;
                    Output += sepA;
                }
                else 
                {
                    Output += obj;
                    Output += sepB;
                }
                count++;
            }
            return Output;
        }
    }
}
