namespace Rental.View
{
    partial class formkeranjang
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listKeranjang1 = new Rental.View.list_item.listKeranjang();
            this.SuspendLayout();
            // 
            // listKeranjang1
            // 
            this.listKeranjang1.Location = new System.Drawing.Point(0, 0);
            this.listKeranjang1.Name = "listKeranjang1";
            this.listKeranjang1.Size = new System.Drawing.Size(1329, 162);
            this.listKeranjang1.TabIndex = 1;
            // 
            // formkeranjang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 767);
            this.Controls.Add(this.listKeranjang1);
            this.Name = "formkeranjang";
            this.Text = "formkeranjang";
            this.ResumeLayout(false);

        }

        #endregion

        private list_item.listKeranjang listKeranjang1;
    }
}