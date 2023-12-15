using Rental.Controler;
using Rental.Modell.Entity;
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
    public partial class tambahmobil : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        ConDasboardAdmin controler = new ConDasboardAdmin();

        string JenisKendaraan;
        string categori;
        public tambahmobil()
        {
            InitializeComponent();
        }

        private void Tambahmobil_Load(object sender, EventArgs e)
        {

            addDataDrop();
        }

        private void addDataDrop()
        {
            List<JenisKendaraan> listjenis = controler.ReadJenis();
            List<Category> listcategories = controler.ReadCategory();

            bunifuDropdown2.Items.Insert(0, "pilih jenis");
            bunifuDropdown2.SelectedIndex = 0;
            bunifuDropdown1.Items.Insert(0, "pilih category");
            bunifuDropdown1.SelectedIndex = 0;

            for (int i = 1; i <= listjenis.Count; i++)
            {
                bunifuDropdown2.Items.Insert(i, listjenis[i - 1].jenis_kendaraan);
            }
            for (int i = 1; i <= listcategories.Count; i++)
            {
                bunifuDropdown1.Items.Insert(i, listcategories[i - 1].categori);
            }

        }

        private void selecimg_Click(object sender, EventArgs e)
        {
            

            // Set properti OpenFileDialog
            openFileDialog.Title = "Pilih Gambar";
            openFileDialog.Filter = "File Gambar|*.jpg;*.png;*.bmp|Semua File|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Menampilkan gambar yang dipilih
                selecimg.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
               
            }
        }

        private int SaveImageToFolder(string imagePath, string folderPath, string newFileName)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string destinationPath = Path.Combine(folderPath, newFileName);
                File.Copy(imagePath, destinationPath);
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            // Menyimpan gambar ke folder yang telah dibuat
            string extension = Path.GetExtension(openFileDialog.FileName);
            string FileName = $"img_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";
            string folderPath = Path.Combine(Application.StartupPath, "../../Assetimg");
            if(SaveImageToFolder(openFileDialog.FileName, folderPath, FileName) <= 0)
            {
                MessageBox.Show("gamabar tidak bisa di apload", "GAGAL",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Kendaraan kendaraan = new Kendaraan();
            kendaraan.nama = bunifuTextBox2.Text;
            kendaraan.img = FileName;
            kendaraan.platNomer = bunifuTextBox3.Text;
            kendaraan.jenis_kendaraan = JenisKendaraan;
            kendaraan.categori = categori;
            kendaraan.harga = bunifuTextBox4.Text;
            kendaraan.merek = merek.Text;
            string pesan = controler.addMobil(kendaraan);
            if (!pesan.Equals(""))
            {
                
                MessageBox.Show(pesan, "GAGAL",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("mobil berhasil di tambah", "BERHASL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void bunifuDropdown2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown2.SelectedIndex != 0)
            {
                JenisKendaraan = bunifuDropdown2.SelectedItem.ToString();
            }
            else
            {
                JenisKendaraan = "";
            }
        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bunifuDropdown1.SelectedIndex != 0)
            {
                categori = bunifuDropdown1.SelectedItem.ToString();
            }
            else
            {
                categori = "";
            }
        }

        
    }
}
