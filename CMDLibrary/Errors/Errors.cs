using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMDLibrary.Convert.Files;

namespace CMDLibrary.Errors
{
    public class Errors
    {
        public Errors() 
        {
            
        }
        public Errors(int errorNum) 
        {
            ErrorNum = errorNum;
            Message = GetError();
        }
        public Errors(int errorNum, string errorFile) 
        {
            ErrorNum = errorNum;
            FilePath = errorFile;
            Message = GetError();
        }
        public string Message { get; set; } = "Unknown Error";
        public int ErrorNum { get; set; } = 0;
        public string FilePath { get; set; } = "C:\\Program Files (x86)\\Miller Inc\\Network App Data\\Error Document.txt";
        public string GetError() 
        {
            string error;
            List<string> errorList = File_List.FileRead(FilePath);
            try
            {
                error = errorList[ErrorNum - 1];
            }
            catch 
            {
                error = "Unknown Error Occured: Try Again Later";
            }
            return error;
        }
        public void NewError(int errorNum) 
        {
            ErrorNum = errorNum;
            Message = GetError();
        }
    }
}
