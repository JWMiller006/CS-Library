using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLibrary.Convert.Lists
{
    public class List_StringNum
    {
        public static string ListStringN(List<string> inList, string sepA, string sepB) 
        {
            string Output = "";
            int count = 0;
            foreach (string obj in inList) 
            {
                if (count < inList.Count)
                {
                    Output += count;
                    Output += ": ";
                    Output += obj;
                    Output += sepA;
                }
                else 
                {
                    Output += count;
                    Output += ": ";
                    Output += obj;
                    Output += sepB;
                }
                count++;
            }
            return Output;
        }
    }
}
