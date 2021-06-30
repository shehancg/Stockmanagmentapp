using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using stockmanagmentapp.mainforms;
using stockmanagmentapp.BLL;
using stockmanagmentapp.DAL.DAO;
using stockmanagmentapp.DAL.DTO;
using stockmanagmentapp.Properties;

namespace stockmanagmentapp
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
            Application.Run(new splashscreen());
        }
    }
}
