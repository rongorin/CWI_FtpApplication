using ICW_FtpApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICW_FtpApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
 
            //Application.Run(new Testform());
            ProcessView view = new ProcessView(true );
            view.Visible = false;

            ProcessController controller = new ProcessController(view);
            controller.LoadView();

            view.ShowDialog();
        

        }
    }
}
