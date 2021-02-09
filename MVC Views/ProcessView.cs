using Controllers;
using ICW_FtpApp.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace MVC_Views
{
    public partial class ProcessView : Form, IProcessView
    {
        ProcessController _controller;

        public ProcessView()
        {
            InitializeComponent();
        }
         


        public void SetController(ProcessController controller)
        {
            _controller = controller;
        }
        public void ClearGrid()
        {
            // Define columns in grid
            this.lvwProcesses.Columns.Clear();

            //this.lvwProcesses.Columns.Add("Id", 150, HorizontalAlignment.Left);
            //this.lvwProcesses.Columns.Add("First Name", 150, HorizontalAlignment.Left);
            //this.lvwProcesses.Columns.Add("Lastst Name", 150, HorizontalAlignment.Left);
            //this.lvwProcesses.Columns.Add("Department", 150, HorizontalAlignment.Left);
            //this.lvwProcesses.Columns.Add("Sex", 50, HorizontalAlignment.Left);

            //// Add rows to grid
            //this.lvwProcesses.Items.Clear();
        }
    }
}
