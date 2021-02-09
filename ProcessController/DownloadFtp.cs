using Controllers.Interfaces;
using Controllers.Services;
using Controllers.Utilities;
using ExportToExcel;
using ICW_FtpApp;
using Model;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks; 

namespace Controllers
{ 
     public class DownloadFtp 
    {
        ICWAccess ICWObj;
        IList _processes;
        private  ILogger LogObj;
        private string _LogPrefix = "Download_FTP";
        public string _AppLogDirectory = "";
        public string _ConnectionString = "";
        public string _SshHostKeyFingerPrint = ""; 
        public string _results = ""; 
        public DataTable _tblExcel; 

        public DownloadFtp(ILogger log) 
        {
            LogObj = log;
        }

        //this constr is just to self-initialise the logging.(otherwise calling program/client would have to pass in Logger)
        public DownloadFtp()
            : this(new LoggerFileService())
        {
        }
        //use to process through all download-processes in the db and then FTP the  files.
        public void ProcessAllFtp(int hrsGoBack)
        {
            _ConnectionString = Helper.LoadConfigKeys("ConnectionString"); // +
                                                     // ";Integrated Security=SSPI; trusted_connection=Yes;";
            _SshHostKeyFingerPrint = Helper.LoadConfigKeys("SshHostKeyFingerPrint"); //not used anymore.
            _processes = GetDataFromDb();
            _AppLogDirectory = Helper.GetMyDir(_ConnectionString);
         
            foreach (Process p in _processes)
            { 
                string res = "For Download ProcessID " + p.ID + " HostIP " + p.HostIP + ": ";
                LogObj.WriteLog(res, enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory);
               
                if (ValidInput(p))
                {
                    _results += res;   

                    FTPProcess ftp = new FTPProcess(p.RAM, p.HostIP, p.Port, p.Login, p.Password, p.RemoteDir, p.Pattern, p.LocalDir, p.PharmacyName,"");
                    ftp.NumDaysGoback(hrsGoBack);
                    ftp.SetExcelTable(_tblExcel);
                                 //ftp.SetFingerPnt(_SshHostKeyFingerPrint); // we not passing the fingerprint, can ascertain it at time of fileDownload.
                     
                    IFtpType requiredTFtp = null;

                    FtpFactory factory = new FtpFactory();
                    requiredTFtp = factory.CreateFtpFactory(p.FtpType, "download",p.RAM, p.Pattern);

                    res = ftp.ComputeFtp(requiredTFtp);  
                    
                    _tblExcel = ftp.GetExcelTbl() ;
                    LogObj.WriteLog(res, enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory);
                    _results += res;
               
                }  
            }

            /*  Create the Excel report */
            LogObj.WriteLog("Completed!", enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory); 
            try
            {
                CreateExcelFile.CreateExcelDocument(_tblExcel, _AppLogDirectory , _LogPrefix);
            }
            catch (Exception ex)
            {
                LogObj.WriteLog("Couldn't create Excel report. nException: " + ex.Message, enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory);
                 
            }  
        }
        public bool ValidInput(Process p)
        {
            string failMsg;

            if (p.HostIP == "" || p.Port == "" || p.Login == "" || p.Password == "" || p.RemoteDir == "" || p.Pattern == "" || p.LocalDir == "")
            {
                failMsg = "For Download ProcessID " + p.ID + " HostIP " + p.HostIP + " Pharm: " + p.PharmacyName + " Validation FAILED" +  "\r\n";
                _results += failMsg;
                LogObj.WriteLog(failMsg, enMsgType.enMsgType_Warn, _LogPrefix, _AppLogDirectory);
                //LogObj.WriteLog(failMsg, enMsgType.enMsgType_Warn, _LogPrefix, _AppLogDirectory);
                return false;
            }

            else
                return true;

        }
        private List<Process> GetDataFromDb()
        {
            ICWObj = new ICWAccess(_ConnectionString); 
            DataTable dt = ICWObj.LoadProcesses(true, "ACTIVE");// get all the Download FTP processes

            List<Process> proclist = dt.DataTableToList<Process>();

            return proclist;
        }
    }
}
