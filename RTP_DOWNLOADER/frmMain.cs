using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace RTP_DOWNLOADER
{
    public partial class frmMain : Form
    {
        private string downloadPath, url;
        private readonly string urlValidation = "www.rtp.pt/play";
        private Programa programa;
        private WebClient webClient = new WebClient();
        private bool websiteLoaded = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.downloadPath = ConfigurationManager.AppSettings["lastSaveLocation"];
            txtPath.Text = this.downloadPath;
            txtPath.Enabled = false;
            panelProgess.Hide();
            progressBarLoadingSite.Hide();

            webClient.DownloadProgressChanged += Client_DownloadProgressChanged;
            webClient.DownloadFileCompleted += Client_DownloadFileCompleted;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "" || downloadPath == "" || !websiteLoaded)
            {
                if (txtUrl.Text == "")
                    MessageBox.Show("URL não especificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (downloadPath == "")
                    MessageBox.Show("Localização para guardar não especificada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!websiteLoaded)
                    MessageBox.Show("Os dados da media ainda estão a ser carregados!");
                return;
            }
            else if (!txtUrl.Text.Contains(urlValidation))
            {
                MessageBox.Show("URL inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HandleDownload();
        }

        private void HandleDownload()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(startDownload);

            worker.RunWorkerAsync();

            WebClient downloadSize = new WebClient();
            downloadSize.OpenRead(programa.getFileURL());
            Int64 bytes_total = Convert.ToInt64(downloadSize.ResponseHeaders["Content-Length"]);
            //MessageBox.Show((bytes_total * Math.Pow(1024, -2)).ToString());

            panelDownload.Hide();
            panelProgess.Show();
        }

        private void startDownload(object sender, DoWorkEventArgs e)
        {
            var fileType = programa.getFileURL().Split('.').Last();
            try
            {
                webClient.DownloadFile(programa.getFileURL(), downloadPath + "\\" + programa.getNomeFormatado() + $".{fileType}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download realizado com sucesso");
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            handleCancel();
        }

        private void handleCancel()
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende sair?", "Aviso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                webClient.CancelAsync();
                panelDownload.Show();
                panelProgess.Hide();
            }

        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = this.downloadPath;
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    this.downloadPath = dialog.FileName;
                    txtPath.Text = this.downloadPath;

                    try
                    {
                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["lastSaveLocation"].Value = this.downloadPath;
                        config.Save(ConfigurationSaveMode.Modified);

                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    catch (Exception)
                    {
                        //can happen if user has not open program has admin
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            if (txtUrl.Text.Contains(urlValidation) && txtUrl.Text != this.url)
            {
                var worker = new BackgroundWorker();
                progressBarLoadingSite.Show();
                worker.DoWork += new DoWorkEventHandler(initializePrograma);
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

                worker.RunWorkerAsync();
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarLoadingSite.Hide();
            websiteLoaded = true;
            lblNome.Text = programa.getNome();
            lblNome.Show();
        }

        private void txtUrl_MouseLeave(object sender, EventArgs e)
        {
            if (txtUrl.Text.Contains(urlValidation) && txtUrl.Text != this.url)
            {
                progressBarLoadingSite.Show();
                var worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(initializePrograma);
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

                worker.RunWorkerAsync();
            }
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            if (txtUrl.Text.Contains(urlValidation) && txtUrl.Text != this.url)
            {
                progressBarLoadingSite.Show();
                var worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(initializePrograma);
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

                worker.RunWorkerAsync();
            }
        }

        private void initializePrograma(object sender, DoWorkEventArgs e)
        {
            websiteLoaded = false;

            this.url = txtUrl.Text;
            string pageContent = null;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(txtUrl.Text);
                HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();
                using (StreamReader sr = new StreamReader(myres.GetResponseStream(), Encoding.ASCII))
                {
                    pageContent = sr.ReadToEnd();
                }

                if (pageContent.Contains("fileKey:"))
                {
                    int index = pageContent.IndexOf("fileKey:");
                    string fileURL = pageContent.Substring(index).Split('\"', '\"')[1];
                    fileURL = "https://ondemand.rtp.pt" + fileURL;

                    index = pageContent.IndexOf("episode-number");
                    string episodio = "0";
                    if (index != -1)
                        episodio = pageContent.Substring(index).Split('>', '<')[1];

                    index = pageContent.IndexOf("vod-title");
                    string nome = "Erro a obter nome";
                    if (index != -1)
                        nome = pageContent.Substring(index).Split('>', '<')[1];
                    else
                    {
                        index = pageContent.IndexOf("twitter:title");
                        if (index != -1)
                            nome = pageContent.Substring(index).Split('\"', '\"')[2];
                    }

                    this.programa = new Programa(nome, episodio, fileURL);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    
                }
            }
        }
    }
}
