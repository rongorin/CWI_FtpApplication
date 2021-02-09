using Controllers.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Services
{
    class ExcelService : ILoggerExcel
    {
        //-------------------------------------
        // Add a row to the in-memory Table 
        //-------------------------------------

        public void WriteExcelrow(string iResult, enMsgType iMsgTyp, string iFilePrefix,
                                  string ipharmacyName, string iFileName, DateTime iLastWriteTime, string iDetails, ref DataTable iTbl)
        {
            if (iTbl == null)
            { 
                iTbl = new DataTable(iFilePrefix + "_Results");
                iTbl.Columns.Add("Pharmacy Name", Type.GetType("System.String"));
                iTbl.Columns.Add("File Name", Type.GetType("System.String"));
                iTbl.Columns.Add("File Creation Date", Type.GetType("System.DateTime"));
                iTbl.Columns.Add("Download Result", Type.GetType("System.String"));
                iTbl.Columns.Add("Details", Type.GetType("System.String"));
            } 
            try
            {
                iTbl.Rows.Add(new object[] { ipharmacyName, iFileName, iLastWriteTime, iResult, iDetails });
                //List<Test> list1 = new List<Test>();
                //list1.Add(new Test() { A = 3, B = "Pharmacy X" });
                //list1.Add(new Test() { A = 4, B = "Pharmacy Z" });
                 
                //iTbl.Rows.Add(new object[] { ,  new DateTime(2017, 3, 19) });
            } 
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
    }
}
