using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Process
    {
  
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; } 
        }
         

        private string _RAM;
        public string RAM
        {
            get { return _RAM; }
            set { _RAM = value; } 
        }
        
        private string _PharmacyName;
        public string PharmacyName
        {
            get { return _PharmacyName; }
            set { _PharmacyName = value; } 
        }
        private string _LocalDir;
        public string LocalDir
        {
            get { return _LocalDir; }
            set { _LocalDir = value; } 
        }

        private string _RemoteDir;
        public string RemoteDir
        {
            get { return _RemoteDir; }
            set { _RemoteDir = value; } 
        }

        private string _HostIP;
        public string HostIP
        {
            get { return _HostIP; }
            set { _HostIP = value; }

        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }

        }

        private string _FtpType;
        public string FtpType
        {
            get { return _FtpType; }
            set { _FtpType = value; }

        }
        private string _Port;
        public string Port
        {
            get { return _Port; }
            set { _Port = value; }

        }
        private string _Login;
        public string Login
        {
            get { return _Login; }
            set { _Login = value; }

        }
        private string _Account;
        public string Account
        {
            get { return _Account; }
            set { _Account = value; }

        }
        private string _Pattern;
        public string Pattern
        {
            get { return _Pattern; }
            set { _Pattern = value; }

        }
        private string _OwnerScheme;  
        public string OwnerScheme
        {
            get { return _OwnerScheme; }
            set { _OwnerScheme = value; }

        }
        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }

        }
 

        public Process()
        { 
        }
        public Process(string ram, string pharmacyName, string localDir, string id, string remoteDir, string hostIP, string password, string login, string ftpType, string account, string pattern, string ownerScheme, string status)
        {
            RAM = ram;
            PharmacyName = pharmacyName;
            LocalDir = localDir;
            RemoteDir = remoteDir;
            ID = id;
            HostIP = hostIP;
            Password = password;
            Login = login;
            FtpType = ftpType;
            Account = account;
            Pattern = pattern;
            OwnerScheme = ownerScheme;
            Status = status; 
          
        }
    }
}
