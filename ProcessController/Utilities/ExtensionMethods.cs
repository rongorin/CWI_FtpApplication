using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controllers.Utilities
{
    static class ExtensionMethods
    {
        public static IEnumerable<SftpFile> ListDirectoryEM(this SftpClient client, string pattern)
        {
            string directoryName = (pattern[0] == '/' ? "" : "/") + pattern.Substring(0, pattern.LastIndexOf('/'));
            string regexPattern = pattern.Substring(pattern.LastIndexOf('/') + 1)
                    .Replace(".", "\\.")
                    .Replace("*", ".*")
                    .Replace("?", ".");
            Regex reg = new Regex('^' + regexPattern + '$');

            var results = client.ListDirectory(String.IsNullOrEmpty(directoryName) ? "/" : directoryName)
                .Where(e => reg.IsMatch(e.Name));
            return results;
        }


        public static FtpWebRequest SetupRequestBasics(this FtpWebRequest ftpRequest, string pass, string user)
        {
            /* Log in to the FTP Server with the User Name and Password Provided */
            ftpRequest.Credentials = new NetworkCredential(user.Normalize(), pass.Normalize());

            /* When in doubt, use these options */
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;

            return ftpRequest; 

        }

        //get a list of files in the required directory that meet the reqrd pattern
        public static string[] GetListing(this FtpWebRequest ftpRequest, string pass, string user)
        {
            ftpRequest = SetupRequestBasics(ftpRequest, pass, user);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            /* Establish Return Communication with the FTP Server */
            //FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            string[] directoryList;
            using (FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
            {
                /* Establish Return Communication with the FTP Server */
                System.IO.Stream ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                System.IO.StreamReader ftpReader = new System.IO.StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try
                {
                    while (ftpReader.Peek() != -1)
                    {
                        directoryRaw += ftpReader.ReadLine() + "|";
                    }
                }
                catch (Exception  )
                {
                }
                directoryRaw = directoryRaw.TrimEnd('|'); 

                ftpReader.Close();
                ftpStream.Close(); 
                ftpRequest = null;
                directoryList = directoryRaw.Split("|".ToCharArray());
            }
        
            /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter   */
         
            return directoryList; 
   
        }

        //get datetime last written
        public static DateTime FileLastWriteTime(this FtpWebRequest ftpRequest,string pass, string user )
         { 
             ftpRequest = SetupRequestBasics(ftpRequest, pass, user); 
            ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            ftpRequest.Proxy = null;
            DateTime lastWritten  ;
            using (FtpWebResponse resp = (FtpWebResponse)ftpRequest.GetResponse())
            {
               lastWritten = resp.LastModified;
               resp.Close();
            }
            ftpRequest = null;

            return lastWritten;

        }

        public static void DownloadFtpFile(this FtpWebRequest ftpRequest, string pass, string user, string localFile)
        {
           int bufferSize = 2048;

           ftpRequest = SetupRequestBasics(ftpRequest, pass, user);
           
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            ftpRequest.UsePassive = false;
            /* Establish Return Communication with the FTP Server */
            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            /* Get the FTP Server's Response Stream */
            System.IO.Stream ftpStream = ftpResponse.GetResponseStream();
            /* Open a File Stream to Write the Downloaded File */
            System.IO.FileStream localFileStream = new System.IO.FileStream(localFile, System.IO.FileMode.Create);
            /* Buffer for the Downloaded Data */

            byte[] byteBuffer = new byte[bufferSize];
            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
            /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
            
                while (bytesRead > 0)
                {
                    localFileStream.Write(byteBuffer, 0, bytesRead);
                    bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                }
            
            /* Resource Cleanup */
            localFileStream.Close();
            ftpStream.Close();
            ftpResponse.Close();
            ftpRequest = null;

        }
    }
}
