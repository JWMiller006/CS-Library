using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CMDLibrary.Net.Google_Drive
{
    public interface IDriveController
    {
        void DeleteFiles();
        List<Google.Apis.Drive.v3.Data.File> FILES(bool conf);
        FileStream GetFile(string fileName);
        List<Google.Apis.Drive.v3.Data.File> GetFiles();
        void GetFilesAsync();
        Task<List<Google.Apis.Drive.v3.Data.File>> GetFilesAsync(double ConfirmationCode);
        void DownloadFile(string fileName);
        void DownloadFileAsync(string fileName);
    }
}