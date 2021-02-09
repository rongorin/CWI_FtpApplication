using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{ 

    public interface IFtpType
    {
        string RunFtp(string hostIP, string port, string user, string pass, string remoteDirectory, string remoteFilePattern, string localFileDirectory, string pharmacyName, string localFileName, int NumHoursGoback, string ram, ref DataTable tblExcel);
    }

}
