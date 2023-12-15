namespace Rental.View.list_item
{
    partial class listKeranjang
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listKeranjang));
            this.status = new Bunifu.UI.WinForms.BunifuLabel();
            this.foto = new System.Windows.Forms.PictureBox();
            this.nama = new Bunifu.UI.WinForms.BunifuLabel();
            this.merek = new Bunifu.UI.WinForms.BunifuLabel();
            this.tipe = new Bunifu.UI.WinForms.BunifuLabel();
            this.plat = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.foto)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AllowParentOverrides = false;
            this.status.AutoEllipsis = false;
            this.status.CursorType = null;
            this.status.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.status.Location = new System.Drawing.Point(1059, 67);
            this.status.Name = "status";
            this.status.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.status.Size = new System.Drawing.Size(181, 28);
            this.status.TabIndex = 6;
            this.status.Text = "Sedang Dikonfirmasi";
            this.status.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.status.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // foto
            // 
            this.foto.Image = ((System.Drawing.Image)(resources.GetObject("foto.Image")));
            this.foto.Location = new System.Drawing.Point(35, 35);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(152, 92);
            this.foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.foto.TabIndex = 31;
            this.foto.TabStop = false;
            // 
            // nama
            // 
            this.nama.AllowParentOverrides = false;
            this.nama.AutoEllipsis = false;
            this.nama.CursorType = null;
            this.nama.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nama.Location = new System.Drawing.Point(238, 67);
            this.nama.Name = "nama";
            this.nama.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nama.Size = new System.Drawing.Size(52, 28);
            this.nama.TabIndex = 32;
            this.nama.Text = "Nama";
            this.nama.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.nama.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // merek
            // 
            this.merek.AllowParentOverrides = false;
            this.merek.AutoEllipsis = false;
            this.merek.CursorType = null;
            this.merek.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.merek.Location = new System.Drawing.Point(461, 67);
            this.merek.Name = "merek";
            this.merek.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.merek.Size = new System.Drawing.Size(45, 28);
            this.merek.TabIndex = 33;
            this.merek.Text = "Merk";
            this.merek.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.merek.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // tipe
            // 
            this.tipe.AllowParentOverrides = false;
            this.tipe.AutoEllipsis = false;
            this.tipe.CursorType = null;
            this.tipe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tipe.Location = new System.Drawing.Point(684, 67);
            this.tipe.Name = "tipe";
            this.tipe.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tipe.Size = new System.Drawing.Size(37, 28);
            this.tipe.TabIndex = 34;
            this.tipe.Text = "Tipe";
            this.tipe.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tipe.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // plat
            // 
            this.plat.AllowParentOverrides = false;
            this.plat.AutoEllipsis = false;
            this.plat.CursorType = null;
            this.plat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.plat.Location = new System.Drawing.Point(907, 67);
            this.plat.Name = "plat";
            this.plat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.plat.Size = new System.Drawing.Size(33, 28);
            this.plat.TabIndex = 35;
            this.plat.Text = "Plat";
            this.plat.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.plat.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // listKeranjang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.plat);
            this.Controls.Add(this.tipe);
            this.Controls.Add(this.merek);
            this.Controls.Add(this.nama);
            this.Controls.Add(this.foto);
            this.Controls.Add(this.status);
            this.Name = "listKeranjang";
            this.Size = new System.Drawing.Size(1329, 162);
            ((System.ComponentModel.ISupportInitialize)(this.foto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel status;
        private System.Windows.Forms.PictureBox foto;
        private Bunifu.UI.WinForms.BunifuLabel nama;
        private Bunifu.UI.WinForms.BunifuLabel merek;
        private Bunifu.UI.WinForms.BunifuLabel tipe;
        private Bunifu.UI.WinForms.BunifuLabel plat;
    }
}
