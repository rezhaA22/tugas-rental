using Rental.Controler;
using Rental.Modell.Entity;
using Rental.View.list_item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental.View
{
    public partial class admin : Form
    {
        public delegate void deleget();

        public event deleget Close;

        public Petugas AdminLogin;

        private string filJenis = "";
        private string filCat = "";
        private string filHarga;

        ConDasboardAdmin repo = new ConDasboardAdmin();

        public admin(Petugas login)
        {
            this.AdminLogin = login;
            InitializeComponent();
        }
        private void admin_Load(object sender, EventArgs e)
        {
            updetList(repo.ReadKendaraan());
            addDataDrop();
        }


        private List<Kendaraan> getFilter(string jenis, string category, string harga)
        {
            List<Kendaraan> listKendaraan = new List<Kendaraan>();

            listKendaraan = repo.filterKendaraan(jenis, category, harga);
            return listKendaraan;
        }


       

        private void updetList(List<Kendaraan> listkendaraan)
        {

            listView.Controls.Clear();

            foreach (Kendaraan kendaraan in listkendaraan)
            {
                listMobilAdmin item = new listMobilAdmin();
                item.Title = kendaraan.nama;
                item.Tipe = kendaraan.categori;
                item.Merk = kendaraan.merek;
                item.Harga = kendaraan.harga;
                item.Plat = kendaraan.platNomer;
                item.Foto = Path.Combine(Application.StartupPath, "../../Assetimg/" + kendaraan.img);
                listView.Controls.Add(item);
            }

        }
        private void addDataDrop()
        {
            List<JenisKendaraan> listjenis = repo.ReadJenis();
            List<Category> listcategories = repo.ReadCategory();

            dropHarga.SelectedIndex = 0;

            dropJenis.Items.Insert(0, "pilih jenis");
            dropJenis.SelectedIndex = 0;
            dropTipe.Items.Insert(0, "pilih category");
            dropTipe.SelectedIndex = 0;

            for (int i = 1; i <= listjenis.Count; i++)
            {
                dropJenis.Items.Insert(i, listjenis[i - 1].jenis_kendaraan);

            }
            for (int i = 1; i <= listcategories.Count; i++)
            {
                dropTipe.Items.Insert(i, listcategories[i - 1].categori);

            }


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            dropHarga.SelectedIndex = 0;
            dropJenis.SelectedIndex = 0;
            dropTipe.SelectedIndex = 0;
            updetList(repo.catriKendaraan(bunifuTextBox1.Text));

        }


        private void bunifuTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dropHarga.SelectedIndex = 0;
                dropJenis.SelectedIndex = 0;
                dropTipe.SelectedIndex = 0;
                updetList(repo.catriKendaraan(bunifuTextBox1.Text));

            }
        }

        private void dropJenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropJenis.SelectedIndex != 0)
            {
                filJenis = dropJenis.SelectedItem.ToString();
            }
            else
            {
                filJenis = "";
            }

            // Pemanggilan  getDataFilter
            updetList(getFilter(filJenis, filCat, filHarga));




        }

        private void dropTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropTipe.SelectedIndex != 0)
            {
                filCat = dropTipe.SelectedItem.ToString();
            }
            else
            {
                filCat = "";
            }

            // Pemanggilan  getDataFilter
            updetList(getFilter(filJenis, filCat, filHarga));
        }

        private void harga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropHarga.SelectedIndex != 0)
            {
                filHarga = (dropHarga.SelectedIndex == 1) ? "ASC" : "DESC";
            }
            else
            {
                filHarga = null;
            }

            // Pemanggilan  getDataFilter
            updetList(getFilter(filJenis, filCat, filHarga));
        }



        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void bunifuIconButton3_Click(object sender, EventArgs e)
        {
            tambahuser formAddUser = new tambahuser();
            formAddUser.ShowDialog();
        }

        private void bunifuIconButton2_Click(object sender, EventArgs e)
        {
            tambahmobil Formtambahmobil = new tambahmobil();
            Formtambahmobil.ShowDialog();
            updetList(repo.ReadKendaraan());
        }

        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            new daftarriwayatadmin(AdminLogin).ShowDialog();
        }
    }
}
