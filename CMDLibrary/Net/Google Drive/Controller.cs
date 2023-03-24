using CMDLibrary.UI.OutputFile;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleFile = Google.Apis.Drive.v3.Data.File;
using Google.Apis.Download;
using CMDLibrary.Files;
using System.Threading;

namespace CMDLibrary.Net.Google_Drive
{
    public class Controller : IController
    {


        #region Initializers

        public Controller()
        {
            try
            {
                NewService();
            }
            catch (FileNotFoundException)
            {

            }
            catch (Exception e)
            {
                Output.WriteLine("Output.txt", e.ToString());
                Console.WriteLine(e.ToString());
            }
        }

        public Controller(string keyFile)
        {
            KeyFile = keyFile;
            NewService();
        }

        public Controller(GoogleCredential credentials)
        {
            Credentials = credentials;
            NewService(Credentials);
        }

        #endregion



        #region Fields (With basic input output modifiers)



        /// <summary>
        /// The stored credentials for the class
        /// </summary>
        internal GoogleCredential Credentials { get; set; }

        /// <summary>
        /// Sets the credentials and creates a new service
        /// </summary>
        /// <param name="credential"></param>
        public void SetCredentials(GoogleCredential credential)
        {
            Credentials = credential;
            NewService(Credentials);
        }



        /// <summary>
        /// The File from which the authentication is derived
        /// </summary>
        internal string KeyFile { get; set; } = "client_secret.json";



        /// <summary>
        /// The DriveServ with autonomously created credentials
        /// </summary>
        public DriveService DriveServ { get; set; }


        #region Base Class Types

        public string ServiceName { get; set; }

        public AboutResource About { get; set; }

        public string APIKey { get; set; }

        public string AppName { get; set; }

        public DateTime LastAccessed { get; set; }

        #endregion


        public List<GoogleFile> DirectFiles { get; set; } = new();


        #endregion



        #region Internal Methods 


        /// <summary>
        /// Sets up a new DriveServ from the file that has already been defined
        /// </summary>
        private void NewService()
        {
            Credentials = GoogleCredential.FromFile(KeyFile).CreateScoped(new[] { DriveService.ScopeConstants.Drive });
            DriveServ = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Credentials
            });
            ServiceName = DriveServ.Name;
            About = DriveServ.About;
            APIKey = DriveServ.ApiKey;
            AppName = DriveServ.ApplicationName;
            LastAccessed = DateTime.Now;
        }

        /// <summary>
        /// Sets up a new DriveServ from the credentials pre-defined
        /// </summary>
        /// <param name="credential"></param>
        private void NewService(GoogleCredential credential)
        {
            DriveServ = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
            ServiceName = DriveServ.Name;
            About = DriveServ.About;
            APIKey = DriveServ.ApiKey;
            AppName = DriveServ.ApplicationName;
            LastAccessed = DateTime.Now;
        }


        /// <summary>
        /// Downloads the Google File input to the output path
        /// </summary>
        /// <param name="file">The Google File that is to be downloaded</param>
        /// <param name="outputPath">The output path that the file is dumped</param>
        public void DownloadFile(GoogleFile file, string outputPath)
        {
            if (CheckCompat(file))
            {
                var request = DriveServ.Files.Get(file.Id);
                var result = request.Execute();
                var stream = new MemoryStream();
                request.MediaDownloader.ProgressChanged += 
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                            { 
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                            case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download Complete");
                                break;
                            }
                            case DownloadStatus.Failed:
                            {
                                    Console.WriteLine("Download Failed");
                                    break;
                            }
                        }
                    };
                request.Download(stream);
                FileControl.SaveStreamAsFile(stream, outputPath);
                var fileOut = result;
                //Files.FileControl.SaveStreamAsFile(fileOut, outputPath);
            }
            // Not complete, but it might work
            else
            {
                var request = DriveServ.Files.Get(file.Id);
                var result = request.Execute();
                var stream = new MemoryStream();
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download Complete");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download Failed");
                                    break;
                                }
                        }
                    };
                request.Download(stream);
                FileControl.SaveStreamAsFile(stream, outputPath);
            }
        }


        /// <summary>
        /// Class method that uses the pre-existing service to download the file to the output location
        /// </summary>
        /// <param name="fileName">The name or id of the file</param>
        /// <param name="outputPath">The output file path</param>
        public void DownloadFile(string fileName, string outputPath)
        {
            GoogleFile storedFile = new();
            var request2 = DriveServ.Files.List();
            Output.WriteLine("output.txt", "Starting New Search");
            var response = request2.Execute();
            foreach (var file in response.Files)
            {
                if ((file.Name == fileName) || (file.Id == fileName))
                {
                    storedFile = file;
                }
            }

            if (CheckCompat(storedFile))
            {
                var request = DriveServ.Files.Get(storedFile.Id);
                var result = request.Execute();
                var stream = new MemoryStream();
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download Complete");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download Failed");
                                    break;
                                }
                        }
                    };
                request.Download(stream);
                FileControl.SaveStreamAsFile(stream, outputPath);
            }
            // Not complete, but it might work
            else
            {
                var request = DriveServ.Files.Get(storedFile.Id);
                var result = request.Execute();
                var stream = new MemoryStream();
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download Complete");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download Failed");
                                    break;
                                }
                        }
                    };
                request.Download(stream);
                FileControl.SaveStreamAsFile(stream, outputPath);
            }
        }


        /// <summary>
        /// Downloads the specified file to the output file
        /// </summary>
        /// <param name="fileName">The name or Id of the file that is being downloaded</param>
        /// <param name="outputPath">The path to the file that the output is copied to</param>
        /// <param name="keyFile">Path to the keyFile</param>
        public async void DownloadFileAsync(string fileName, string outputPath)
        {
            GoogleFile storedFile = new();
            var request2 = DriveServ.Files.List();
            Output.WriteLine("output.txt", "Starting New Search");
            var response = request2.Execute();
            foreach (var file in response.Files)
            {
                if ((file.Name == fileName) || (file.Id == fileName))
                {
                    storedFile = file;
                }
            }

            if (CheckCompat(storedFile))
            {
                var request = DriveServ.Files.Get(storedFile.Id);
                var result = request.Execute();
                var stream = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Write);
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download Complete");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download Failed");
                                    break;
                                }
                        }
                    };
                await request.DownloadAsync(stream);
                //await FileControl.SaveStreamAsFileAsync(stream, outputPath);
                stream.Close();
            }
            // Not complete, but it might work
            else
            {
                var request = DriveServ.Files.Get(storedFile.Id);
                var result = request.Execute();
                var stream = new MemoryStream();
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download Complete");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download Failed");
                                    break;
                                }
                        }
                    };
                await request.DownloadAsync(stream);
                await FileControl.SaveStreamAsFileAsync(stream, outputPath);
                stream.Close();

            }
        }



        /// <summary>
        /// This is the Function that can be used async or sync just follow the DownloadHandler style
        /// </summary>
        /// <param name="fileName">Name of File to Search and download</param>
        /// <param name="outputPath">Path of File to download to</param>
        /// <param name="keyFile">Path to key file</param>
        /// <returns></returns>
        public static async Task DownloadFileAsync(string fileName, string outputPath, string keyFile)
        {
            GoogleFile storedFile = new();
            var driveServ = NewService(keyFile);
            var request2 = driveServ.Files.List();
            Output.WriteLine("output.txt", "Starting New Search");
            var response = request2.Execute();
            foreach (var file in response.Files)
            {
                if ((file.Name == fileName) || (file.Id == fileName))
                {
                    storedFile = file;
                }
            }

            if (CheckCompat(storedFile))
            {
                var request = driveServ.Files.Get(storedFile.Id);
                var result = request.Execute();
                var stream = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Write);
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download Complete");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download Failed");
                                    break;
                                }
                        }
                    };
                await request.DownloadAsync(stream);
                //await FileControl.SaveStreamAsFileAsync(stream, outputPath);
                stream.Close();
            }
            // Not complete, but it might work
            else
            {
                var request = driveServ.Files.Get(storedFile.Id);
                var result = request.Execute();
                var stream = new MemoryStream();
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download Complete");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download Failed");
                                    break;
                                }
                        }
                    };
                await request.DownloadAsync(stream);
                await FileControl.SaveStreamAsFileAsync(stream, outputPath);
                stream.Close();

            }
        }


        #endregion



        #region Usable Methods


        /// <summary>
        /// Gets a list of the files in drive and stores them and metadata in the list
        /// </summary>
        public List<GoogleFile> GetFiles()
        {
            // Get Files 
            var request = DriveServ.Files.List();
            Output.WriteLine("output.txt", "Starting New Search");
            var response = request.Execute();
            foreach (var file in response.Files)
            {
                //Console.WriteLine($"{file.Id} {file.Name} {file.MimeType} {file.Properties}");
                Output.WriteLine("output.txt", $"{file.Id} {file.Name} {file.MimeType} {file.Properties}");
            }
            DirectFiles = (List<GoogleFile>)response.Files;
            Output.WriteLine("output.txt", "Done fetching files");
            return DirectFiles;
        }




        /// <summary>
        /// Checks if the File able to be downloaded to the current device
        /// </summary>
        /// <param name="file">The file that is to be checked</param>
        /// <returns>The boolean of compatibility</returns>
        public static bool CheckCompat(GoogleFile file)
        {
            List<string> mimeTypes = new() { "text/plain", "application/zip", "application/pdf", "text/csv" };
            try
            {
                return Check.IsIn(file.MimeType, mimeTypes);
            }
            catch
            {
                return false;
            }
        }


        #endregion



        #region Static Methods 


        /// <summary>
        /// Downloads a file from the drive without creating a new object
        /// </summary>
        /// <param name="file">The GoogleFileStore specified for downloading</param>
        /// <param name="outputPath">The output location for the download data</param>
        /// <param name="keyFile">The path to the key file</param>
        public static void DownloadFile(GoogleFile file, string outputPath, string keyFile)
        {
            DriveService driveService = NewService(keyFile);
            var request = driveService.Files.Get(file.Id);
            var result = request.Execute();
            var stream = new MemoryStream();
            request.MediaDownloader.ProgressChanged +=
                progress =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download Complete");
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                Console.WriteLine("Download Failed");
                                break;
                            }
                    }
                };
            request.Download(stream);
            FileControl.SaveStreamAsFile(stream, outputPath);
        }



        /// <summary>
        /// Downloads the specified file to the output file
        /// </summary>
        /// <param name="fileName">The name or Id of the file that is being downloaded</param>
        /// <param name="outputPath">The path to the file that the output is copied to</param>
        /// <param name="keyFile">Path to the keyFile</param>
        public static void DownloadFile(string fileName, string outputPath, string keyFile)
        {
            DriveService driveService = NewService(keyFile);
            GoogleFile storedFile = new();
            var request2 = driveService.Files.List();
            Output.WriteLine("output.txt", "Starting New Search");
            var response = request2.Execute();
            foreach (var file in response.Files)
            {
                if ((file.Name == fileName) || (file.Id == fileName))
                {
                    storedFile = file;
                }
            }

            var request = driveService.Files.Get(storedFile.Id);
            var result = request.Execute();
            var stream = new MemoryStream();
            //var stream = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            request.MediaDownloader.ProgressChanged +=
                progress =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Output.WriteLine("output.txt", progress.BytesDownloaded.ToString());
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Output.WriteLine("output.txt","Download Complete");
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                Output.WriteLine("output.txt","Download Failed");
                                break;
                            }
                    }
                };
            request.Download(stream);
            //FileControl.SaveStreamAsFile(stream, outputPath);
            stream.Close();
            Output.WriteLine("output.txt", "Function Complete");
        }



        /// <summary>
        /// Gets a new driveservice from the specified file key
        /// </summary>
        /// <param name="keyFile">The path to the key file</param>
        /// <returns>A new DriveServ</returns>
        public static DriveService NewService(string keyFile)
        {
            var credentials = GoogleCredential.FromFile(keyFile).CreateScoped(new[] { DriveService.ScopeConstants.Drive });
            var driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials
            });
            return driveService;
        }


        #endregion



        #region Overrides 


        /// <summary>
        /// Override ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            output += ServiceName + "\n";
            output += APIKey + "\n";
            output += About.ToString() + "\n";
            output += "Last Accessed: " + LastAccessed;
            return output;
        }


        #endregion



        #region Download Stages


        public static async void DownloadHandler(string file, string fileName, string keyFile)
        {
            await DownloadFileAsync(file, fileName, keyFile);
            Console.WriteLine("File Download Complete");
        }



        #endregion

    }
}
