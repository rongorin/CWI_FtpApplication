using Controllers;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICW_FtpApp.Controller
{
    public class ProcessController
    {
        IProcessView _view; 
        IList      _processes;
        Process   _selectedProcess;
          
        ICWAccess ICWObj; 
        public ProcessController(IProcessView view)
        { 
            ICWObj = new ICWAccess(Helper.LoadConfigKeys("ConnectionString"));// + ";Integrated Security=SSPI; trusted_connection=Yes;");
 

            _view = view;
            view.SetController(this);  //pass the contoller instance to the view 
        }

        //this overload is used by the Upload.
        public ProcessController(IProcessView view, string ownerScheme)
        {
            ICWObj = new ICWAccess(Helper.LoadConfigKeys("ConnectionString")) ;//+ ";Integrated Security=SSPI; trusted_connection=Yes;");


            _view = view;

            _view.OwnerScheme = ownerScheme; 
            view.SetController(this);  //pass the contoller instance to the view 
        }  
       
        public void LoadView()
        {   
            _processes = GetDataFromDb();
             
            _view.ClearGrid();
            foreach (Process p in _processes)
                _view.AddProcToGrid(p);

            if (_processes.Count> 0)
                 _view.SetSelectedProcessInGrid((Process)_processes[0]);

        }
        public void SelectedProcessChanged(string selectedID)
        {
            foreach (Process p in _processes)
            {
                if (p.ID == selectedID)
                {
                    _selectedProcess = p;
                    updateViewDetailValues(p); 
                    _view.SetSelectedProcessInGrid(p);
                    _view.CanModifyID = false;
                    break;
                }
            }
        } 

        private  List<Process> GetDataFromDb()
        {  
            DataTable dt = ICWObj.LoadProcesses(_view.IsDownload, "" ,_view.OwnerScheme);

            List<Process> proclist = dt.DataTableToList<Process>();

            return proclist;
        }

        public void Save()
        {
            updateProcessWithViewValues(_selectedProcess);
            if (! _processes.Contains(_selectedProcess))
            {
                // Add a new Process
                InsertIntoDb(_selectedProcess);
                this._processes.Add(_selectedProcess);
                this._view.AddProcToGrid(_selectedProcess);
            }
            else
            {
                UpdateToDb(_selectedProcess); 
                this._view.UpdateGridWithChangedProcess(_selectedProcess);
            }
            _view.SetSelectedProcessInGrid(_selectedProcess);
            this._view.CanModifyID = false;
             
        }
        public void AddNewProcess()
        {
            _selectedProcess = new Process("", "", "", "", "", "", "", "", "", "", "", "", "ACTIVE");

            this.updateViewDetailValues(_selectedProcess);
            this._view.CanModifyID = false;
        }
        public void UpdateToDb(Process process)
        {
            try
            {
                ICWObj.UpdateProcess(process, _view.IsDownload); 

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public void InsertIntoDb(Process process)
        {
            try
            {
                int newid = ICWObj.InsertNewProcess(process, _view.IsDownload);
                process.ID = newid.ToString();

            }
            catch (Exception ex)
            {  
                throw ex;
            }

        }
        public void RemoveProcess()
        {
            string id = this._view.GetIdOfSelectedProcessInGrid();
            Process processToRemove = null;

            if (id != "")
            {
                foreach (Process usr in this._processes)
                {
                    if (usr.ID == id)
                    {
                        processToRemove = usr;
                        break;
                    }
                }

                if (processToRemove != null)
                {
                    int newSelectedIndex = this._processes.IndexOf(processToRemove);
                    this._processes.Remove(processToRemove);
                    this._view.RemoveFromGrid(processToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _processes.Count)
                    {
                        this._view.SetSelectedProcessInGrid((Process)_processes[newSelectedIndex]);
                    }
                }
            }
        }

        private void updateViewDetailValues(Process proc)
        {
            _view.RAM = proc.RAM;
            _view.PharmacyName = proc.PharmacyName;
            _view.LocalDir = proc.LocalDir;
            _view.RemoteDir = proc.RemoteDir;
            _view.ID = proc.ID;
            _view.HostIP = proc.HostIP;
            _view.Port = proc.Port;
            _view.FtpType = proc.FtpType;
            _view.Password = proc.Password;
            _view.Login = proc.Login;
            _view.Account = proc.Account;
            _view.Pattern = proc.Pattern;
            _view.OwnerScheme = proc.OwnerScheme;
            _view.Status = proc.Status; 
                    
        }

        private void updateProcessWithViewValues(Process proc)
        {
            proc.RAM = _view.RAM;
            proc.PharmacyName = _view.PharmacyName;
            proc.LocalDir = _view.LocalDir;
            proc.RemoteDir = _view.RemoteDir;
            proc.ID = _view.ID;
            proc.HostIP = _view.HostIP;
            proc.FtpType = _view.FtpType;
            proc.Port = _view.Port;
            proc.Password = _view.Password;
            proc.Login = _view.Login;
            proc.Account = _view.Account;
            proc.Pattern = _view.Pattern;
            proc.OwnerScheme = _view.OwnerScheme;
            proc.Status = _view.Status; 
             
        }

       

    }
}
