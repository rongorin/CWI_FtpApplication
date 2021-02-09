using Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class FTPProcess  
    {
        public string _results = "";
        string hostIP; 
        string port ;
        string user;
        string pass; 
        string remoteDirectory;
        string ram;
        string remoteFilePattern; string localFileDirectory;
        string localFileName;
        string pharmacyName;
        int numDaysGoback;
        DataTable tblExcel; 
        public FTPProcess(string iram, string ihostIP, string iport, string iuser, string ipass, string iremoteDirectory, string iremoteFilePattern, string ilocalFileDirectory,string ipharmacyName, string ilocalFileName)
        {
              hostIP = ihostIP;
              port= iport;
              user= iuser;
              pass = ipass;
              ram = iram;
              remoteDirectory = iremoteDirectory;
              remoteFilePattern  = iremoteFilePattern;
              localFileDirectory = ilocalFileDirectory;
              localFileName = ilocalFileName;
              pharmacyName = ipharmacyName;
             
 
        }
        public void NumDaysGoback(int iNumDaysGoback)
        {
            numDaysGoback = iNumDaysGoback;
        }

        public void SetExcelTable(DataTable iTblExcel)
        {
            tblExcel = iTblExcel;
        }
        //public void SetFingerPnt(string iHostFingerPrint)
        //{
        //    sshHostKeyFingerPrint = iHostFingerPrint;
        //}
        
        public DataTable  GetExcelTbl( )
        {
            return tblExcel ; 
        }
        //abstract the types of Ftp behind the interface:
        public string ComputeFtp(IFtpType ftp)
        {
            return ftp.RunFtp(hostIP, port, user, pass, remoteDirectory, remoteFilePattern, localFileDirectory, pharmacyName, localFileName, numDaysGoback, ram, ref tblExcel);
        }
    }
}
