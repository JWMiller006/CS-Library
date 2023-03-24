using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using GoogleFile = Google.Apis.Drive.v3.Data.File;
using System;
using System.Collections.Generic;

namespace CMDLibrary.Net.Google_Drive
{
    public interface IController
    {
        List<GoogleFile> DirectFiles { get; set; }
        DriveService DriveServ { get; set; }
        DateTime LastAccessed { get; set; }

        void DownloadFile(GoogleFile file, string outputPath);
        void DownloadFile(string fileName, string outputPath);
        void DownloadFileAsync(string fileName, string outputPath);
        List<GoogleFile> GetFiles();
        void SetCredentials(GoogleCredential credential);
        string ToString();
    }
}