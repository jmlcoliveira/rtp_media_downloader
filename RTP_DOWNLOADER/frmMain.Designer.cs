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
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.panelDownload = new System.Windows.Forms.TableLayoutPanel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.progressBarDownloadStatus = new System.Windows.Forms.ProgressBar();
            this.panelProgess = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.verificarProcesso = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelDownload.SuspendLayout();
            this.panelProgess.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Download Media RTP Play";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 402F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 50);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelInfo
            // 
            this.panelInfo.ColumnCount = 4;
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.21086F));
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.9511F));
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.74199F));
            this.panelInfo.Controls.Add(this.label3, 1, 2);
            this.panelInfo.Controls.Add(this.txtUrl, 2, 1);
            this.panelInfo.Controls.Add(this.label2, 1, 1);
            this.panelInfo.Controls.Add(this.btnSelectFolder, 3, 2);
            this.panelInfo.Controls.Add(this.txtPath, 2, 2);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 50);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.RowCount = 3;
            this.panelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.panelInfo.Size = new System.Drawing.Size(626, 151);
            this.panelInfo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(98, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Salvar para:";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(168, 59);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(324, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Leave += new System.EventHandler(this.txtUrl_Leave);
            this.txtUrl.MouseLeave += new System.EventHandler(this.txtUrl_MouseLeave);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(69, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Link do Programa:";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSelectFolder.Location = new System.Drawing.Point(498, 113);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(116, 23);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "Escolher Pasta";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(168, 115);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(324, 20);
            this.txtPath.TabIndex = 2;
            // 
            // panelDownload
            // 
            this.panelDownload.ColumnCount = 1;
            this.panelDownload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelDownload.Controls.Add(this.btnDownload, 0, 0);
            this.panelDownload.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDownload.Location = new System.Drawing.Point(0, 201);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.RowCount = 1;
            this.panelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelDownload.Size = new System.Drawing.Size(626, 36);
            this.panelDownload.TabIndex = 3;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDownload.Location = new System.Drawing.Point(275, 6);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // progressBarDownloadStatus
            // 
            this.progressBarDownloadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDownloadStatus.Location = new System.Drawing.Point(281, 6);
            this.progressBarDownloadStatus.Name = "progressBarDownloadStatus";
            this.progressBarDownloadStatus.Size = new System.Drawing.Size(253, 23);
            this.progressBarDownloadStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarDownloadStatus.TabIndex = 4;
            // 
            // panelProgess
            // 
            this.panelProgess.ColumnCount = 4;
            this.panelProgess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.panelProgess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.32029F));
            this.panelProgess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.67971F));
            this.panelProgess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.panelProgess.Controls.Add(this.progressBarDownloadStatus, 2, 0);
            this.panelProgess.Controls.Add(this.btnCancel, 1, 0);
            this.panelProgess.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProgess.Location = new System.Drawing.Point(0, 237);
            this.panelProgess.Name = "panelProgess";
            this.panelProgess.RowCount = 1;
            this.panelProgess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelProgess.Size = new System.Drawing.Size(626, 36);
            this.panelProgess.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Location = new System.Drawing.Point(200, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // verificarProcesso
            // 
            this.verificarProcesso.Interval = 5000;
            this.verificarProcesso.Tick += new System.EventHandler(this.verificarProcesso_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(626, 240);
            this.Controls.Add(this.panelProgess);
            this.Controls.Add(this.panelDownload);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1080, 279);
            this.MinimumSize = new System.Drawing.Size(440, 279);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RTP Play Downloads";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelDownload.ResumeLayout(false);
            this.panelProgess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel panelInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel panelDownload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar progressBarDownloadStatus;
        private System.Windows.Forms.TableLayoutPanel panelProgess;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Timer verificarProcesso;
    }
}

