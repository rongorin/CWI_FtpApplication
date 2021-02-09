using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Utilities
{ 
    public interface ILogger
    {
        void WriteLog(string iMsg, enMsgType iMsgTyp, string iLogFilePrefix, string iPath);
    }
    //--
}
