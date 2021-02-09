using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Utilities
{
  
    //public class Logger : ILogger
    //{  
    //    private readonly ILogger _logger;

    //    public Logger(ILogger logger) // constr
    //    {
    //        _logger = logger; 
    //    }

    //    public void WriteExcelrow(string iResult, enMsgType iMsgTyp, string iFilePrefix,
    //                string ipharmacyName, string iFileName, DateTime iLastWriteTime, string iDetails ,ref DataTable iTbl)
    //    {
    //        if (iTbl == null)
    //        {

    //            iTbl = new DataTable(iFilePrefix + "_Results");
    //            iTbl.Columns.Add("Pharmacy Name", Type.GetType("System.String"));
    //            iTbl.Columns.Add("File Name", Type.GetType("System.String"));
    //            iTbl.Columns.Add("File Creation Date", Type.GetType("System.DateTime"));
    //            iTbl.Columns.Add("Download Result", Type.GetType("System.String"));
    //            iTbl.Columns.Add("Details", Type.GetType("System.String"));
    //        }
    //        try
    //        {
    //            iTbl.Rows.Add(new object[] { ipharmacyName, iFileName, iLastWriteTime, iResult, iDetails });
    //            //List<Test> list1 = new List<Test>();
    //            //list1.Add(new Test() { A = 3, B = "Pharmacy X" });
    //            //list1.Add(new Test() { A = 4, B = "Pharmacy Z" });


    //            //iTbl.Rows.Add(new object[] { ,  new DateTime(2017, 3, 19) });
    //        }
                     
    //        catch (Exception Ex)
    //        {
    //            throw Ex;
    //        } 
                    
    //    }
    //    public void WriteLog(string iMsg, enMsgType iMsgTyp, string iLogFilePrefix, string iPath)
    //    {
    //        string LogPathAndFileName = iPath;
    //        string myMsg = iMsg; 
    //        try
    //        { 
    //            if (LogPathAndFileName.LastIndexOf("\\") != LogPathAndFileName.Length - 1)// 'Make sure there is a \ at the end of the path
    //                LogPathAndFileName = LogPathAndFileName + "\\";
    //            LogPathAndFileName = LogPathAndFileName + iLogFilePrefix + "_" + DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + ".log";
                  
    //            switch (iMsgTyp)
    //            {
    //                case enMsgType.enMsgType_Info:

    //                    LogMsg("INFO" + iLogFilePrefix, myMsg, LogPathAndFileName);
                        
    //                    break;
    //                case enMsgType.enMsgType_Ok:
    //                    LogMsg ("OK", myMsg, LogPathAndFileName);
    //                    break;
    //                case enMsgType.enMsgType_Warn:
    //                    LogMsg("WARN", myMsg, LogPathAndFileName);
                    
    //                    break;
    //                case enMsgType.enMsgType_Error:  
    //                    myMsg = "An error occurred in the processing. \n" + iMsg;
    //                    LogMsg("ERROR", myMsg, LogPathAndFileName);
         
    //                    break;
    //                default:
    //                    LogMsg("UNKNOWN!", myMsg, LogPathAndFileName);
    //                    break;
    //            }
    //        }
    //        catch (Exception Ex)
    //        {
    //            throw Ex;
    //        }
    //    }

    //    private void LogMsg(string iStatus, string iMsg, string iPathAndFileName)
    //    {
    //        System.IO.StreamWriter myWriter;
    //        string myLine = ""; 

    //        try
    //        {
    //            myLine = DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + 
    //                      DateTime.Now.Millisecond.ToString("00") + "\t" + iStatus + "\t\t" + iMsg;
    //            myWriter = System.IO.File.AppendText(iPathAndFileName);
    //            try
    //            {
    //                myWriter.WriteLine(myLine);
    //                myWriter.Flush();
    //                myWriter.Close();
    //            }
    //            catch (Exception SubEx)
    //            {
    //                throw SubEx;
    //            }
    //            finally
    //            {
    //                myWriter.Dispose();
    //            }
    //        }
    //        catch (Exception Ex)
    //        {
    //            throw Ex;

    //        }
    //    }
   // }
}
