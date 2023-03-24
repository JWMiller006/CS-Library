using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMDLibrary.Files
{
    public class EditFile
    {
        public static string EditFileLine(string file, int lineNum, string newLine) 
        {
            string Output = "File editing not started";
            string[] arrLine = File.ReadAllLines(file);
            arrLine[lineNum] = newLine;
            Output = "Line has been replaced";
            File.WriteAllLines(file, arrLine);
            Output = "Edit has been made";
            return Output;
        }
        public static string EditFileAll(string file, string[] newFile) 
        {
            string Output = "File editing not started";
            File.WriteAllLines(file, newFile);
            Output = "Edit has been made";
            return Output;
        }
        public static void FileAddLine(string file, string newLine)
        {
            string[] arrLine = File.ReadAllLines(file);
            arrLine.Append(newLine);
            //Console.WriteLine(arrLine.ToString());
            File.AppendAllText(file, Environment.NewLine + newLine);
        }
    }
}
