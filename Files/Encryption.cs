using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Personal Libraries
using CMDLibrary.Convert;
using CMDLibrary.Files;

namespace CMDLibrary.Files
{
    public class Encryption
    {
        public static List<string> ReadDecrypted(string file) 
        {
            var output = new List<string> { };
            File.Decrypt(file);
            output.AddRange(Convert.Files.File_List.FileRead(file));
            File.Encrypt(file);
            return output;
        }
    }
}
