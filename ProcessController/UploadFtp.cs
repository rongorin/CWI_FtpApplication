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
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
 
namespace Controllers
{
    public class UploadFtp
    {
        IList _processes;
        ICWAccess ICWObj;


        enum TypeOfFTP
        {
            None,
            SFTP = 1,
            FTP = 2
        };

        private ILogger LogObj;
        private string _LogPrefix = "Upload_FTP";
        public string _AppLogDirectory = "";
        public string _ConnectionString = "";
        public string _results = "";
        public DataTable _tblExcel; 
        public string _UploadFolder ="";
        public List<string> _SelectedUploadIDs;
        public UploadFtp(ILogger log)
        {
            LogObj = log;
        }

        //this constr is just to self-initialise the logging.(otherwise calling program/client would have to pass in Logger)
        public UploadFtp() 
            : this(new LoggerFileService())
        { 
        }
        public void ProcessAllFtp()
        {
            _ConnectionString = Helper.LoadConfigKeys("ConnectionString");// +";Integrated Security=SSPI; trusted_connection=Yes;";

            try{
                 _processes = GetDataFromDb(); 
            }
            catch (Exception ex)
            {
                LogObj.WriteLog("Failed Accessing DB for windows user identity " + WindowsIdentity.GetCurrent() + " error:" + ex.Message, enMsgType.enMsgType_Error, _LogPrefix, _AppLogDirectory);

            }  
            _AppLogDirectory = Helper.GetMyDir(_ConnectionString) ;
             
            foreach (Process p in _processes)
            {
                string res = "For Upload ProcessID " + p.ID + " HostIP " + p.HostIP + ": ";
                LogObj.WriteLog(res, enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory);
                     
                if (ValidInput(p))
                { 
                    _results += res;

                    p.LocalDir = _UploadFolder; //we change it to the user-selected folder !

                    FTPProcess ftp = new FTPProcess(p.RAM, p.HostIP, p.Port, p.Login, p.Password, p.RemoteDir, p.Pattern,
                                                    _UploadFolder, p.PharmacyName, "not used here");
                    ftp.SetExcelTable(_tblExcel);

                    IFtpType requiredTFtp = null;

                    FtpFactory factory = new FtpFactory();
                    requiredTFtp = factory.CreateFtpFactory(p.FtpType, "upload","","");

                    res = ftp.ComputeFtp(requiredTFtp); 
                     
                    _tblExcel = ftp.GetExcelTbl();
                    LogObj.WriteLog(res, enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory);
                    _results += res;
                }
                 //  LogObj.WriteLog(res, enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory);

                _results +=  "\r\n"; 
            }

            LogObj.WriteLog("Completed!", enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory);
            /*  Create the Excel report */
            try
            {
                if (_tblExcel == null)
                    throw new Exception("No Excel Report content was generated");

                CreateExcelFile.CreateExcelDocument(_tblExcel, _AppLogDirectory, _LogPrefix);
            }
            catch (Exception ex)
            {
                LogObj.WriteLog("Couldn't create Excel report. nException: " + ex.Message, enMsgType.enMsgType_Info, _LogPrefix, _AppLogDirectory);

            }  
        }
        public bool ValidInput(Process p)
        {
            string failMsg  ;
            //see if this row is in the user-selected List. If not,do not upload.
            if (_SelectedUploadIDs.IndexOf(p.ID) == -1)
                return false;

            if (p.HostIP == "" || p.Port == "" || p.Login == "" || p.Password == "" || p.RemoteDir == "" || p.Pattern == "" || p.LocalDir == "" || p.RAM == "")
            {
                 failMsg = "For Upload ProcessID " + p.ID + " HostIP " + p.HostIP + " RAM: " + p.RAM + " Pharm: " + p.PharmacyName + " Validation FAILED" + "\r\n" + "\r\n";
                _results += failMsg;
                 LogObj.WriteLog(failMsg, enMsgType.enMsgType_Warn, _LogPrefix, _AppLogDirectory);
                 return false;
            }  
            else
                return true;

        }
        private List<Process> GetDataFromDb()
        { 
                ICWObj = new ICWAccess(_ConnectionString);
                DataTable dt = new DataTable();
                List<Process> proclist = new List<Process>();

                try
                {
                   
                    dt = ICWObj.LoadProcesses(false, "ACTIVE", "");// get all the upload FTP processes       
                    proclist = dt.DataTableToList<Process>();
                }
                catch (Exception ex)
                {
                    LogObj.WriteLog("Failed Accessing DB for windows user identity " + WindowsIdentity.GetCurrent() + " error:" + ex.Message, enMsgType.enMsgType_Error, _LogPrefix, _AppLogDirectory);

                }  
                return proclist;
        }



    }
}
