using Rental.Controler;
using Rental.Model.Entity;
using Rental.Model.Repository;
using Rental.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental
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
            Form1 login = new Form1();


            Application.Run(new admin(new Modell.Entity.Petugas()));

        }
    }
}
