using Controllers.Interfaces;
using Controllers.Services;
using Controllers.Utilities;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinSCP;

namespace Controllers
{

    //public interface IFtpType
    //{
    //    string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int NumHoursGoback, ref DataTable tblExcel);
    //}

    public class DownloadFtpType : IFtpType
    {
        private readonly ILoggerExcel LogObj;
        public DownloadFtpType(ILoggerExcel log)
        {
            LogObj = log;
        }
            //this constr is just to self-initialise the logging.(otherwise calling program/client would have to pass in Logger)
        public DownloadFtpType()
            : this(new ExcelService())
        {
        }
        string result = "";
        FtpWebRequest ftpRequest = null; 
        string localFileDirWithDateTime; 
        string filePrefix = "FTPDownload";

        public string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int NumHoursGoback, string ram, ref DataTable tblExcel)
        {
            try
            {
                localFileDirWithDateTime = Helper.CreateDirectory(localFileDirectory, DateTime.Now, pharmacyName);
            }
            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                pharmacyName, "", DateTime.Now, "Failed trying to create a local Dir in " + localFileDirectory + ". Ftp for this pharm stopped.", ref tblExcel);
                return ("Failure trying to create a directory in " + localFileDirectory + " for pharmacy " + pharmacyName + ". error:" + ex.Message);
            }

            try
            { 
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(@"ftp://" + hostIP + "/" + remoteDirectory + "/" + remoteFilePattern);  

                string[] downfiles = ExtensionMethods.GetListing(ftpRequest , pass, user); //get listing of files.
             
                if (downfiles.Count() == 0)
                    LogObj.WriteExcelrow("No Files", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "", ref tblExcel);


                foreach (string downfileName in downfiles)
                {
                    string localFilename = localFileDirWithDateTime + downfileName;
               
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(@"ftp://" + hostIP + "/" + remoteDirectory + "/" + downfileName);
                    DateTime lastWriteTime = ExtensionMethods.FileLastWriteTime(ftpRequest, pass, user );

                    if (lastWriteTime >= DateTime.Now.AddHours(NumHoursGoback * -1))   // ignore if older that the num Hours Goback spec by user
                    {
                        try
                        {
                            
                            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(@"ftp://" + hostIP + "/" + remoteDirectory + "/" + downfileName);
                            ExtensionMethods.DownloadFtpFile(ftpRequest, pass, user, localFilename);   
                          
                            result += downfileName + "\r\n";
                            LogObj.WriteExcelrow("Success", enMsgType.enMsgType_Info, filePrefix,
                                                                pharmacyName, downfileName, lastWriteTime, "", ref tblExcel);
                        }
                        catch (Exception ex)
                        {
                            LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                            pharmacyName, downfileName, lastWriteTime, ex.Message, ref tblExcel);

                            return "Failure occurred trying to Download Ftp file " + downfileName + " for HostIp " + hostIP + " directory " + remoteDirectory + " files " + remoteFilePattern + " error:" + ex.Message + "\r\n";
                        }
                    }
                    else
                    {
                        result += "Ignored" + downfileName + " as its too old." + "\r\n";
                        LogObj.WriteExcelrow("Ignored", enMsgType.enMsgType_Info, filePrefix,
                                                            pharmacyName, downfileName, lastWriteTime, "its too old", ref tblExcel);
                    }
                  
                }
                return "Successfully downloaded to local dir " + localFileDirectory + " the following files: " + result;
            }
            catch (Exception ex)
            {  
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "Cant connect to HostIp " + hostIP, ref tblExcel);
                return ("Failure occurred trying to connect to download Ftp for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");
            }
        }
    }
    public class DownloadSFtpWinSCPType : IFtpType
    {
        private readonly ILoggerExcel LogObj;

        public DownloadSFtpWinSCPType(ILoggerExcel log)
        {
            LogObj = log;
        }
     //this constr is just to self-initialise the logging.(otherwise calling program/client would have to pass in Logger)


        public DownloadSFtpWinSCPType()
            : this(new ExcelService())
        {
        }
        public string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int numHoursGoback, string ram, ref DataTable tblExcel)
        {
            string result = "";
            string localFileDirWithDateTime;
            string filePrefix = "SFTPDownload";

            try
            {
                localFileDirWithDateTime = Helper.CreateDirectory(localFileDirectory, DateTime.Now, pharmacyName);
            }
            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                pharmacyName, "", DateTime.Now, "Failed trying to create a local Dir in " + localFileDirectory + ". Ftp for this pharm stopped.", ref tblExcel);
                return ("Failure trying to create a directory in " + localFileDirectory + " for pharmacy " + pharmacyName + ". error:" + ex.Message);
            }

            try
            {//------------------------------------------------------------------------------------------------
                WinSCP.SessionOptions sessionOptions = new WinSCP.SessionOptions
                {
                    Protocol = WinSCP.Protocol.Sftp,
                    HostName = hostIP,
                    UserName = user,
                    Password = pass,
                    PortNumber =  Convert.ToInt32(port) 
                        /* use these to connect to FTP, and leave out the fingerPrint.:
                        * 
                           _with1.Protocol = Protocol.Ftp;
                           _with1.FtpSecure = FtpSecure.Explicit; 
                        * 
                        */ 
                };
                string fingerprint = null; 
                using (WinSCP.Session session = new WinSCP.Session())
                {
                    fingerprint = session.ScanFingerprint(sessionOptions); 
                }
                if (fingerprint == null)
                    throw new Exception("Couldnt determine Host Fingerprint");
                else
                    sessionOptions.SshHostKeyFingerprint = fingerprint; 
                

                using (WinSCP.Session session = new WinSCP.Session())
                {
                    sessionOptions.Timeout = TimeSpan.FromMinutes(6);  // 6 min timeout
                                            //session.ExecutablePath = @"C:\Software\v11\winscp.exe";
                    session.Open(sessionOptions);
                     
                    WinSCP.TransferOptions transferOptions = new WinSCP.TransferOptions();
                    transferOptions.TransferMode = WinSCP.TransferMode.Binary;

                    WinSCP.TransferOperationResult transferResult = default(WinSCP.TransferOperationResult);
                    transferResult = session.GetFiles(remoteDirectory + remoteFilePattern, localFileDirectory, false, transferOptions);

                    transferResult.Check();
                    //THrows the first error if not successful 
                    foreach (WinSCP.TransferEventArgs transfer in transferResult.Transfers)
                    {
                        string downfileName = transfer.FileName; 

                        DateTime remoteWriteTime =
                            session.GetFileInfo(downfileName).LastWriteTime; //get the DateTime of the file.

                        if (remoteWriteTime >= DateTime.Now.AddHours(numHoursGoback * -1))   // ignore if older that the num Hours Goback spec by user
                        {
                            string localFilename = localFileDirWithDateTime + downfileName;
                            //try
                            //{
                              
                            result += downfileName + "\r\n";
                            LogObj.WriteExcelrow("Success", enMsgType.enMsgType_Info, filePrefix,
                                                                 pharmacyName, downfileName, remoteWriteTime, "", ref tblExcel);
                            // }
                            //catch (Exception ex)
                            //{
                            //    LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                            //                                    pharmacyName, downfileName, remoteWriteTime, ex.Message, ref tblExcel);

                            //    return "Failure occurred trying to Download SecureFtpWinSCP file " + downfileName + " for HostIp " + hostIP + " directory " + remoteDirectory + " files " + remoteFilePattern + " error:" + ex.Message + "\r\n";
                            //}
                        }
                        else
                        {
                            result += "Should be Ignored" + downfileName + " but still nowloaded." + "\r\n";

                            LogObj.WriteExcelrow("Success", enMsgType.enMsgType_Info, filePrefix,
                                            pharmacyName, downfileName, remoteWriteTime, " but still nowloaded.", ref tblExcel);

                            //LogObj.WriteExcelrow("Ignored", enMsgType.enMsgType_Info, filePrefix,
                            //                                    pharmacyName, downfileName, file.Attributes.LastWriteTime, "its too old", ref tblExcel);
                        }

                    } 
                }
                //-------------------------------------------------------------------------------------------------------------------

               
                return "Successfully downloaded to local dir " + localFileDirectory + " the following files: " + result;

            }
            catch (WinSCP.SessionRemoteException ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "Check the remote settings. " + ex.Message, ref tblExcel);
                return ("Failure occurred trying to connect to download SFtp for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");

            }

            catch (System.TimeoutException ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, ex.Message, ref tblExcel);
                return ("Failure occurred trying to connect to download SFtp for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");

            }


            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, ex.Message, ref tblExcel);

                return ("Failure occurred trying to connect to download SFtp for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");
            }
        } 
    }

    // normal Sftp download using Renci.SshNet.Sftp
    public class DownloadSFtpType : IFtpType
    {
        private readonly ILoggerExcel LogObj;

        public DownloadSFtpType(ILoggerExcel log)
        {
            LogObj = log;
        }

        //this constr is just to self-initialise the logging.(otherwise calling program/client would have to pass in Logger)
        public DownloadSFtpType()
            : this(new ExcelService())
        {
        }

        public string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int numHoursGoback, string ram, ref DataTable tblExcel)
        {
            string result = "";
            string localFileDirWithDateTime;
            string filePrefix = "SFTPDownload";

            try
            {
                localFileDirWithDateTime = Helper.CreateDirectory(localFileDirectory, DateTime.Now, pharmacyName);
            }
            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                pharmacyName, "", DateTime.Now, "Failed trying to create a local Dir in " + localFileDirectory + ". Ftp for this pharm stopped.", ref tblExcel);
                return ("Failure trying to create a directory in " + localFileDirectory + " for pharmacy " + pharmacyName + ". error:" + ex.Message);
            }

            try
            {
                using (var sftp = new SftpClient(hostIP, Convert.ToInt32(port), user, pass))
                {
                    sftp.Connect();

                    List<SftpFile> downFiles = ExtensionMethods.ListDirectoryEM(sftp, remoteDirectory + remoteFilePattern).ToList();

                    foreach (var file in downFiles)
                    {
                        string downfileName = file.Name;

                        if (file.Attributes.LastWriteTime >= DateTime.Now.AddHours(numHoursGoback * -1))   // ignore if older that the num Hours Goback spec by user
                        {
                            string localFilename = localFileDirWithDateTime + downfileName;
                            try
                            {
                                using (var fileLocal = File.OpenWrite(localFilename))
                                {
                                    sftp.DownloadFile(remoteDirectory + downfileName, fileLocal);
                                }
                                result += downfileName + "\r\n";
                                LogObj.WriteExcelrow("Success", enMsgType.enMsgType_Info, filePrefix,
                                                                 pharmacyName, downfileName, file.Attributes.LastWriteTime, "", ref tblExcel);
                            }
                            catch (Exception ex)
                            {
                                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                                pharmacyName, downfileName, file.Attributes.LastWriteTime, ex.Message, ref tblExcel);

                                return "Failure occurred trying to Download SecureSFtp file " + downfileName + " for HostIp " + hostIP + " directory " + remoteDirectory + " files " + remoteFilePattern + " error:" + ex.Message + "\r\n";
                            }
                        }
                        else
                        {
                            result += "Ignored" + downfileName + " as its too old." + "\r\n";
                            LogObj.WriteExcelrow("Ignored", enMsgType.enMsgType_Info, filePrefix,
                                                                pharmacyName, downfileName, file.Attributes.LastWriteTime, "its too old", ref tblExcel);
                        }
                    }

                    if (downFiles.Count() == 0)
                        LogObj.WriteExcelrow("No Files", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "", ref tblExcel);

                    sftp.Disconnect();
                }
                return "Successfully downloaded to local dir " + localFileDirectory + " the following files: " + result;

            }
            catch (WinSCP.SessionRemoteException ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "Check the remote settings. " + ex.Message, ref tblExcel);
                return ("Failure occurred trying to connect to download SFtp for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");

            }

            catch (System.TimeoutException ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, ex.Message, ref tblExcel);
                return ("Failure occurred trying to connect to download SFtp for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");

            }


            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, ex.Message, ref tblExcel);

                return ("Failure occurred trying to connect to download SFtp for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");
            }


        }
    }
    //  Sftp download of a single specified file using Renci.SshNet.Sftp
    public class DownloadSFtpSinglefileType : IFtpType 
    {
        private readonly ILoggerExcel LogObj;

        public DownloadSFtpSinglefileType(ILoggerExcel log) 
        {
            LogObj = log;
        }

        //this constr is just to self-initialise the logging.(otherwise calling program/client would have to pass in Logger)
        public DownloadSFtpSinglefileType()
            : this(new ExcelService())
        {
        }
           
        public string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int numHoursGoback, string ram, ref DataTable tblExcel)
        {
            string result = "";
            string localFileDirWithDateTime;
            string filePrefix = "SFTPDownload";
             
            try
            {
                localFileDirWithDateTime = Helper.CreateDirectory(localFileDirectory, DateTime.Now, pharmacyName);   
            }
            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                pharmacyName, "", DateTime.Now, "Failed trying to create a local Dir in " + localFileDirectory + ". Ftp for this pharm stopped." , ref tblExcel);
                return ("Failure trying to create a directory in " + localFileDirectory + " for pharmacy " + pharmacyName  + ". error:" + ex.Message);
            }  
             
            try
            { 
                int ramInt;
                if (!int.TryParse(ram.Trim(), out ramInt))
                {
                    throw new Exception("RAM is not a valid number: " + ram);

                }

                using (var sftp = new SftpClient(hostIP, Convert.ToInt32(port), user, pass))
                { 
                    sftp.Connect();
                     
                    string downfileName = String.Format("M{0:D7}.MUL", ramInt); 

                        //if (file.Attributes.LastWriteTime >= DateTime.Now.AddHours(numHoursGoback * -1))   // ignore if older that the num Hours Goback spec by user
                        //{  
                            string localFilename = localFileDirWithDateTime + downfileName;
                            try
                            {
                                string targetFilename = String.Format("{0}/{1}", remoteDirectory, downfileName);
                       
                                using (var fileLocal = File.OpenWrite(localFilename))
                                {
                                    sftp.DownloadFile(targetFilename, fileLocal);
                                }
                                result += downfileName + "\r\n";
                                LogObj.WriteExcelrow("Success",  enMsgType.enMsgType_Info, filePrefix ,
                                                                 pharmacyName, downfileName, DateTime.Now, "", ref tblExcel);
                            }
                            catch (Renci.SshNet.Common.SftpPathNotFoundException exr)
                            {
                                LogObj.WriteExcelrow("Failure - No file", enMsgType.enMsgType_Info, filePrefix,
                                                                pharmacyName, downfileName, DateTime.Now, exr.Message, ref tblExcel);

                                return "Failure occurred trying to Download SecureSFtp file " + downfileName + " for HostIp " + hostIP + " directory " + remoteDirectory + " files " + remoteFilePattern + " error:" + exr.Message + "\r\n";
                            }
                            catch (Exception ex)
                            {
                                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                                pharmacyName, downfileName, DateTime.Now, ex.Message, ref tblExcel);
                                
                                return "Failure occurred trying to Download SecureSFtp file " + downfileName + " for HostIp " + hostIP + " directory " + remoteDirectory + " files " + remoteFilePattern + " error:" + ex.Message + "\r\n";
                            }

                        //  we are downloading single file. Here cannot immediately check if file is outdated.
                        //}
                        //else
                        //{
                        //    result += "Ignored" + downfileName + " as its too old." + "\r\n";
                        //    LogObj.WriteExcelrow("Ignored", enMsgType.enMsgType_Info, filePrefix,
                        //                                        pharmacyName, downfileName, file.Attributes.LastWriteTime, "its too old", ref tblExcel); 
                        //}
                  

                    //if (downFiles.Count() == 0)
                    //    LogObj.WriteExcelrow("No Files", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "", ref tblExcel);

                    sftp.Disconnect();
                }
                return "Successfully downloaded to local dir " + localFileDirectory + " the following files: " + result;
 
            }
            //catch (WinSCP.SessionRemoteException ex)
            //{
            //    LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "Check the remote settings. " + ex.Message, ref tblExcel);
            //    return ("Failure occurred trying to connect to download SFtp(single) for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");

            //}

            catch (System.Net.Sockets.SocketException exe)
            {
                LogObj.WriteExcelrow("Failure - Socket", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, exe.Message, ref tblExcel);
                return ("Failure occurred trying to connect to download SFtp(single) for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + exe.Message + "\r\n");

            }
            catch (Renci.SshNet.Common.SshOperationTimeoutException ext)
            {
                LogObj.WriteExcelrow("Failure - Timeout", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, ext.Message, ref tblExcel);
                return ("Failure occurred trying to connectu to download SFtp(single) for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ext.Message + "\r\n");

            } 
            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, ex.Message, ref tblExcel);

                return ("Failure occurred trying to connect to download SFtp(single) for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");
            }

     
        } 
    }
    //  Bulk upload: upload all the user-selected pharmacies . Location of upload files to upload are determined 
    //  by the RAM Num in the folder name.
    public class UploadBulkSecureSFtpType : IFtpType
    {
        private readonly ILoggerExcel LogObj;

        public UploadBulkSecureSFtpType(ILoggerExcel log)
        {
            LogObj = log;
        } 
        //this constr is just to self-initialise the logging.(otherwise calling program/client would have to pass in Logger)
        public UploadBulkSecureSFtpType()
            : this(new ExcelService())
        {
        }
        string filePrefix = "SFTPUpload";

        public string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int NumHoursGoback, string ram, ref DataTable tblExcel)
        {
            string result = "";

            try
            {
                using (var sftp = new SftpClient(hostIP, Convert.ToInt32(port), user, pass))
                {
                    sftp.Connect();

                    sftp.ChangeDirectory(remoteDirectory);

                    string[] uplFilesArr = Directory.GetFiles(localFileDirectory + "\\" + ram, remoteFilePattern); //NOTE: remoteFilePattern contains Localfile Pattern!!

                    foreach (var uploadFile in uplFilesArr)
                    {
                        try
                        {
                            using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                            {
                                sftp.BufferSize = 4 * 1024;
                                sftp.UploadFile(fileStream, Path.GetFileName(uploadFile));
                            }
                            result += uploadFile + "\r\n";
                            LogObj.WriteExcelrow("Success", enMsgType.enMsgType_Info, filePrefix,
                                                     pharmacyName, uploadFile, DateTime.Now, "", ref tblExcel);

                        }
                        catch (Exception ex)
                        {
                            LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                pharmacyName, uploadFile, DateTime.Now, "", ref tblExcel);
                            return ("Failure occurred trying to Upload SecureSFtp file " + uploadFile + " for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");
                        }
                    }
                    if (uplFilesArr.Count() == 0)
                        LogObj.WriteExcelrow("No Files", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "", ref tblExcel);

                    sftp.Disconnect();

                }
                return "Successfully uploaded to remote dir " + remoteDirectory + " the following files: " + result;
            }
            catch (DirectoryNotFoundException e)
            {
                LogObj.WriteExcelrow("Failure", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "Could not find Local dir for RAM " + ram, ref tblExcel);
                return ("Failure " + e.Message + " for " +pharmacyName+ "\r\n");
            }
            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "Cant connect to HostIp " + hostIP, ref tblExcel);
                return ("Failure occurred trying to connect to SecureSFtp HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");
            }
        }
    }

    //this is not currently used as Upload now just does the Bulk uploading (above)
    public class UploadSecureSFtpType : IFtpType
    {
      private readonly ILoggerExcel LogObj;

        public UploadSecureSFtpType(ILoggerExcel log) 
        {
            LogObj = log;
        }

        //this constr is just to self-initialise the logging.(otherwise calling program/client would have to pass in Logger)
        public UploadSecureSFtpType()
            : this(new ExcelService())
        {
        }
        string filePrefix = "SFTPUpload"; 

        public string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int NumHoursGoback,string ram, ref DataTable tblExcel)
        {
            string result = "";  
 
            try
            {
                using (var sftp = new SftpClient(hostIP, Convert.ToInt32(port), user, pass))
                {
                    sftp.Connect();
      
                    sftp.ChangeDirectory(remoteDirectory);

                    string[] uplFilesArr = Directory.GetFiles(localFileDirectory, remoteFilePattern); //contains Localfile Pattern!!
                     
                    foreach (var uploadFile in uplFilesArr)
                    {   
                        try 
                        {
                            using (var fileStream = new FileStream(uploadFile, FileMode.Open))  
                            { 
                                sftp.BufferSize = 4 * 1024;
                                sftp.UploadFile(fileStream, Path.GetFileName(uploadFile));
                            }
                            result += uploadFile + "\r\n";
                            LogObj.WriteExcelrow("Success", enMsgType.enMsgType_Info, filePrefix,
                                                     pharmacyName, uploadFile, DateTime.Now, "", ref tblExcel);
                    
                        }
                        catch (Exception ex)
                        {
                            LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix,
                                                pharmacyName, uploadFile, DateTime.Now, "", ref tblExcel); 
                            return ("Failure occurred trying to Upload SecureSFtp file " + uploadFile + " for HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");
                        }
                    }
                    if (uplFilesArr.Count() == 0)
                        LogObj.WriteExcelrow("No Files", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "", ref tblExcel);

                    sftp.Disconnect();
           
                }
                return "Successfully uploaded to remote dir " + remoteDirectory + " the following files: " + result;
            }
            catch (Exception ex)
            {
                LogObj.WriteExcelrow("Failure!", enMsgType.enMsgType_Info, filePrefix, pharmacyName, "", DateTime.Now, "Cant connect to HostIp " + hostIP, ref tblExcel);  
                return ("Failure occurred trying to connect to SecureSFtp HostIp " + hostIP + " directory " + remoteDirectory + remoteFilePattern + " error:" + ex.Message + "\r\n");
            }
        } 
    }
     
    public class UploadFtpType : IFtpType
    {
        //public DateTime EarliestLastWrite(int hoursGoBack)
        //{
        //    return DateTime.Now.AddHours(hoursGoBack * -1);
        //} 

        string remoteFileName;

        public string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int NumHoursGoback, string ram, ref DataTable tblExcel)
        {
            FtpWebRequest ftpRequest = null;
            Stream ftpStream = null;
            int bufferSize = 2048;
            try
            {
                remoteFileName = Helper.CreateRemoteFilename(localFileName);

                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(@"ftp://" + hostIP + "/" + remoteDirectory + "//" + remoteFileName);

                ftpRequest = ExtensionMethods.SetupRequestBasics(ftpRequest, pass, user);   

                /* Log in to the FTP Server with the User Name and Password Provided */
                //ftpRequest.Credentials = new NetworkCredential(user.Normalize(), pass.Normalize());
                 
                ///* When in doubt, use these options */
                //ftpRequest.UseBinary = true;
                //ftpRequest.UsePassive = true;
                //ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpRequest.GetRequestStream();

                /* Open a File Stream to Read the File for Upload */
                FileStream localFileStream = new FileStream(localFileName, FileMode.Open);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesSent != 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                } 
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;
            }
            catch (Exception ex)
            {
                return ("Failure trying to send file " + remoteFileName + " to hostIP " + hostIP + " Error:" + ex.Message);
 
            }
            return remoteFileName + "\r\n"; // success 
        }
    } 
}
