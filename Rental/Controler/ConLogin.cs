using Rental.Model.Repository;
using Rental.Modell.Context;
using Rental.Modell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental.Controler
{
    public class ConLogin
    {
        DbContext context = new DbContext();
        RepoPetugas repo;

        public ConLogin()
        {
            repo = new RepoPetugas(context);
        }

        public Petugas login(String id, string pass)
        {
            string pesan = "";

            if (id.Equals(""))
            {
                pesan += "id ";
            }
            if (pass.Equals(""))
            {
                pesan += " pasword";
            }
            if (!pesan.Equals(""))
            {
                MessageBox.Show(pesan+" harus di isi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            Petugas user = repo.ReadLogin(id, pass);

            return user;
        }

       

    }

    




}
