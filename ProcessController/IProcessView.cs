using ICW_FtpApp.Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
     
    public interface IProcessView
    {
        //void SetController(ProcessController controller);
         void ClearGrid();
         void SetController(ProcessController controller);
         void AddProcToGrid(Process proc);
         void SetSelectedProcessInGrid(Process proc);
         void UpdateGridWithChangedProcess(Process proc);
         void RemoveFromGrid(Process proc);
         string GetIdOfSelectedProcessInGrid();

         string RAM { get; set; }
         string PharmacyName { get; set; }
         string LocalDir { get; set; }
         string RemoteDir { get; set; }
         string ID { get; set; }
         string HostIP { get; set; }
         string Port { get; set; }
         string Password { get; set; }
         string Login { get; set; }
         string FtpType { get; set; }
         string Account { get; set; }
         string Pattern { get; set; }
         string OwnerScheme { get; set; }
         string Status { get; set; }


         bool CanModifyID { set; }
         bool IsDownload { get; }
          
    }
    
}
