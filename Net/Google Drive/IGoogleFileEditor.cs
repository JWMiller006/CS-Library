using GoogleFile = Google.Apis.Drive.v3.Data.File;
using System.Collections.Generic;

namespace CMDLibrary.Net.Google_Drive
{
    public interface IGoogleFileEditor
    {
        string FileId { get; set; }
        string FileName { get; set; }
        GoogleFile GoogleFileStore { get; set; }
        List<string> Lines { get; set; }

        void DeleteLine(int index);
        bool Equals(object obj);
        int GetHashCode();
        void InsertLine(string line, int index);
        void OverWrite(List<string> lines);
        void OverWriteLine(string line);
        void OverWriteLine(string line, int lineNum);
        string ToString();
        void UpdateFile();
        void Write(string text);
        void WriteLine(string line);
        void WriteLine(string text, int line);
    }
}