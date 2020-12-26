namespace RTP_DOWNLOADER
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.progressBarLoadingSite = new System.Windows.Forms.ProgressBar();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.progressBarDownloadStatus = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.gbDownloadDetails = new System.Windows.Forms.GroupBox();
            this.gbDownloadStatus = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbDownloadDetails.SuspendLayout();
            this.gbDownloadStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Salvar para:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(135, 24);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(408, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            this.txtUrl.Leave += new System.EventHandler(this.txtUrl_Leave);
            this.txtUrl.MouseLeave += new System.EventHandler(this.txtUrl_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Link do Programa:";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.ForeColor = System.Drawing.Color.Black;
            this.btnSelectFolder.Location = new System.Drawing.Point(564, 94);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(97, 20);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "Escolher Pasta";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(135, 94);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(408, 20);
            this.txtPath.TabIndex = 2;
            // 
            // progressBarLoadingSite
            // 
            this.progressBarLoadingSite.Location = new System.Drawing.Point(564, 27);
            this.progressBarLoadingSite.Name = "progressBarLoadingSite";
            this.progressBarLoadingSite.Size = new System.Drawing.Size(97, 13);
            this.progressBarLoadingSite.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarLoadingSite.TabIndex = 4;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(319, 53);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(33, 13);
            this.lblNome.TabIndex = 5;
            this.lblNome.Text = "nome";
            this.lblNome.Visible = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(303, 216);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(107, 29);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // progressBarDownloadStatus
            // 
            this.progressBarDownloadStatus.Location = new System.Drawing.Point(149, 30);
            this.progressBarDownloadStatus.Name = "progressBarDownloadStatus";
            this.progressBarDownloadStatus.Size = new System.Drawing.Size(347, 23);
            this.progressBarDownloadStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarDownloadStatus.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(46, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timerDownload
            // 
            this.timerDownload.Interval = 1000;
            this.timerDownload.Tick += new System.EventHandler(this.timerDownload_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(201, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "RTP Play Media Download";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // gbDownloadDetails
            // 
            this.gbDownloadDetails.Controls.Add(this.txtPath);
            this.gbDownloadDetails.Controls.Add(this.lblNome);
            this.gbDownloadDetails.Controls.Add(this.progressBarLoadingSite);
            this.gbDownloadDetails.Controls.Add(this.btnSelectFolder);
            this.gbDownloadDetails.Controls.Add(this.label2);
            this.gbDownloadDetails.Controls.Add(this.label3);
            this.gbDownloadDetails.Controls.Add(this.txtUrl);
            this.gbDownloadDetails.ForeColor = System.Drawing.Color.White;
            this.gbDownloadDetails.Location = new System.Drawing.Point(12, 52);
            this.gbDownloadDetails.Name = "gbDownloadDetails";
            this.gbDownloadDetails.Size = new System.Drawing.Size(676, 133);
            this.gbDownloadDetails.TabIndex = 6;
            this.gbDownloadDetails.TabStop = false;
            this.gbDownloadDetails.Text = "Dados Download";
            // 
            // gbDownloadStatus
            // 
            this.gbDownloadStatus.Controls.Add(this.lblStatus);
            this.gbDownloadStatus.Controls.Add(this.progressBarDownloadStatus);
            this.gbDownloadStatus.Controls.Add(this.btnCancel);
            this.gbDownloadStatus.ForeColor = System.Drawing.Color.White;
            this.gbDownloadStatus.Location = new System.Drawing.Point(100, 193);
            this.gbDownloadStatus.Name = "gbDownloadStatus";
            this.gbDownloadStatus.Size = new System.Drawing.Size(527, 73);
            this.gbDownloadStatus.TabIndex = 7;
            this.gbDownloadStatus.TabStop = false;
            this.gbDownloadStatus.Text = "Estado Download";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(149, 51);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(347, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "0MB/0MB";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(632, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "By jmlcoliveira";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(702, 284);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbDownloadStatus);
            this.Controls.Add(this.gbDownloadDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RTP Play Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbDownloadDetails.ResumeLayout(false);
            this.gbDownloadDetails.PerformLayout();
            this.gbDownloadStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar progressBarDownloadStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ProgressBar progressBarLoadingSite;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Timer timerDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDownloadDetails;
        private System.Windows.Forms.GroupBox gbDownloadStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
    }
}

