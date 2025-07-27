
namespace UniversalMobileFlasher
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbChipset;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnFlash;
        private System.Windows.Forms.ListBox lstLog;

        private void InitializeComponent()
        {
            this.cmbChipset = new System.Windows.Forms.ComboBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnFlash = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // cmbChipset
            this.cmbChipset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChipset.Items.AddRange(new object[] {
                "Fastboot",
                "Qualcomm (EDL)",
                "MediaTek (MTK)"});
            this.cmbChipset.Location = new System.Drawing.Point(12, 12);
            this.cmbChipset.Size = new System.Drawing.Size(200, 21);

            // txtFilePath
            this.txtFilePath.Location = new System.Drawing.Point(12, 40);
            this.txtFilePath.Size = new System.Drawing.Size(300, 20);

            // btnBrowse
            this.btnBrowse.Location = new System.Drawing.Point(320, 38);
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            // btnFlash
            this.btnFlash.Location = new System.Drawing.Point(12, 70);
            this.btnFlash.Size = new System.Drawing.Size(100, 23);
            this.btnFlash.Text = "Flash Now";
            this.btnFlash.Click += new System.EventHandler(this.btnFlash_Click);

            // lstLog
            this.lstLog.Location = new System.Drawing.Point(12, 100);
            this.lstLog.Size = new System.Drawing.Size(380, 180);

            // MainForm
            this.ClientSize = new System.Drawing.Size(404, 291);
            this.Controls.Add(this.cmbChipset);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnFlash);
            this.Controls.Add(this.lstLog);
            this.Text = "Universal Mobile Flasher";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
