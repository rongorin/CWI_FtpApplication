using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public enum enMsgType
    {
        enMsgType_Info = 1,
        enMsgType_Warn = 2,
        enMsgType_Error = 3,
        enMsgType_Ok = 4
    } 
     
    public static class Helper
    {
        public static string LoadConfigKeys(string iKeyName)
        {
            System.Configuration.AppSettingsReader ConfigReader = new System.Configuration.AppSettingsReader();
            try
            {
                return (string)ConfigReader.GetValue(iKeyName, System.Type.GetType("System.String")) ;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        } 
        /// Converts a DataTable to a list with generic objects 
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static string CreateRemoteFilename(string filename)
        {
            FileInfo myFileDetail = new FileInfo(filename);
            return myFileDetail.Name.Substring(0, myFileDetail.Name.Length);
            //return  myFileDetail = myFileDetail.Name.Substring(0, myFileDetail.Name.Length - 4);
        }

        public static string CreateDirectory(string prefixDir, DateTime? timestmp, string addNestedDir = "")
        {
            string fullDirName;
             
            //string fullDirName = string.Format("{0}{1:yyyyMMdd Hmmss}", prefixDir, DateTime.Now);
            if (timestmp != null)
                fullDirName = string.Format("{0}{1:yyyyMMdd}{2}", prefixDir, timestmp, "\\");
            else
                fullDirName = string.Format("{0}{1}", prefixDir,"\\");

            if (!Directory.Exists(fullDirName))
                Directory.CreateDirectory(fullDirName);

            if (addNestedDir != "")
            {
                fullDirName += string.Format("{0}{1}", addNestedDir, "\\");

                if (!Directory.Exists(fullDirName))
                    Directory.CreateDirectory(fullDirName);  
            } 

            return fullDirName;
        }


        public static string GetMyDir(string iConnString)
        {
            System.IO.FileInfo myFileInfo;
            System.IO.DirectoryInfo myDirInfo;
            System.Diagnostics.Process myProcess;

            string myDir = "";
            try
            {
                myProcess = System.Diagnostics.Process.GetCurrentProcess();
                myFileInfo = new System.IO.FileInfo(myProcess.MainModule.FileName);
                myDirInfo = myFileInfo.Directory;
                myDir = myDirInfo.FullName;

                System.IO.Directory.SetCurrentDirectory(myDir); //Change the directory to the actual application directory
                if (myDir.LastIndexOf("\\") != myDir.Length - 1)
                    myDir = myDir + "\\";

                //test for the log folder - create if neccessary
                myDir += "Logs";
                if (!Directory.Exists(myDir ))
                    Directory.CreateDirectory(myDir );
                 
                return myDir;
            }
            catch (Exception Ex)
            {
                WriteMyEventLog("Error occurred. cannot Get My Directory! ", Ex.Message.ToString(), iConnString);
                return "";
            }
        }
        private static void WriteMyEventLog(string iMyMsg, string iErrorMsg, string iConnString)
        {
            try
            {
                if (!System.Diagnostics.EventLog.SourceExists("CWIFtpApp"))
                    System.Diagnostics.EventLog.CreateEventSource("CWIFtpApp", "CWIFtpAppLog");
                System.Diagnostics.EventLog myLog = new System.Diagnostics.EventLog();
                myLog.Source = "CWIFtpApp";
                if (iErrorMsg != "")
                    myLog.WriteEntry(iMyMsg + " for db: " + iConnString +
                                " Error:" + iErrorMsg);
                else
                    myLog.WriteEntry(iMyMsg + " for db: " + iConnString) ; 

            }
            catch (Exception Ex)
            {
                WriteMyEventLog("Error: Cannot Write to the Event Log! ", Ex.Message.ToString(), iConnString);
                throw Ex;
            }
        }
    }

}
