using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Utilities
{
    public interface ILoggerExcel
    {
         void WriteExcelrow(string iResult, enMsgType iMsgTyp, string iFilePrefix,
                    string ipharmacyName, string iFileName, DateTime iLastWriteTime, string iDetails ,ref DataTable iTbl);
 
     }
 }
 
