using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DowloadFtp
    {
        private Process DowloadProcess;

        public DowloadFtp(Process p)
        {
            DowloadProcess = p;
            try
            {
                using (var sftp = new SftpClient(hostIP, 1573, user, pass))
                {

                    sftp.Connect();
                    Regex r = new Regex("^Del.*");
                    // var downFiles = ExtensionMethods.ListDirectoryEM(sftp, remoteDirectory + remoteFilePattern);  // returns:  /u/go/ZTSCRPT.01

                    List<SftpFile> downFiles = ExtensionMethods.ListDirectoryEM(sftp, remoteDirectory + remoteFilePattern).ToList();

                    foreach (var file in downFiles)
                    {
                        string downfileName = file.Name;
                        string localFilename = localFileDirectory + "\\" + downfileName;
                        using (var fileLocal = File.OpenWrite(localFilename))
                        {
                            sftp.DownloadFile(remoteDirectory + downfileName, fileLocal);
                        }
                        res += downfileName + "\r\n";
                    }
                    //foreach (var file in Directory.GetFiles(remoteDirectory, "ZTSCRP*"))
                    //{
                    //    string remoteFileName = Path.GetFileName(file);

                    //    using (var fileLocal = File.OpenWrite(localFilename))
                    //    {
                    //        sftp.DownloadFile(remoteDirectory + remoteFileName, fileLocal);
                    //    }

                    //    res += "Successfully downloaded file " + remoteFileName;
                    //}
                    //-----------------------

                    sftp.Disconnect();
                }
                return "Successfully downloaded files: " + res;
            }
            catch (Exception ex)
            {
                throw new Exception("Failure occurred trying to DOWnload file " + remoteDirectory + remoteFilePattern + " error:" + ex.Message);
            }
        }
   
    }
}
