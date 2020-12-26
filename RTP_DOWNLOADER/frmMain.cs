using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using RTP_DOWNLOADER.Properties;
using System.Drawing;

namespace RTP_DOWNLOADER
{
    public partial class frmMain : Form
    {
        private string downloadPath, url;
        private readonly string urlValidation = "www.rtp.pt/play";
        private Programa programa;
        private WebClient webClient = new WebClient();
        private bool hasWebsiteBeenLoaded = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.downloadPath = Settings.Default["downloadPath"].ToString();
            txtPath.Text = this.downloadPath;
            txtPath.Enabled = false;
            gbDownloadStatus.Hide();
            progressBarLoadingSite.Hide();

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "" || downloadPath == "" || !hasWebsiteBeenLoaded)
            {
                if (txtUrl.Text == "")
                    MessageBox.Show("URL não especificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (downloadPath == "")
                    MessageBox.Show("Localização para guardar não especificada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!hasWebsiteBeenLoaded)
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
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted1;

            worker.RunWorkerAsync();

            timerDownload.Start();


            gbDownloadStatus.Show();
        }

        //worker finnished event leting know the download has been concluded
        private void Worker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarDownloadStatus.Value = getPrograssBarSize();
            timerDownload.Stop();
            reset();
        }

        //reset form status
        private void reset()
        {
            txtUrl.Text = "";
            progressBarDownloadStatus.Value = 0;
            gbDownloadStatus.Hide();
            lblNome.Hide();
        }

        private void startDownload(object sender, DoWorkEventArgs e)
        {
            try
            {
                string name = downloadPath + "\\" + programa.getNomeFormatado() + programa.getFileType();

                webClient.DownloadFile(programa.getFileURL(), name);
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("aborted"))
                    MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            handleCancel();
        }

        private void handleCancel()
        {
            var dialogResult = MessageBox.Show("Tem a certeza que pretende cancelar?", "Questão", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                webClient.CancelAsync();
                gbDownloadStatus.Hide();
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
                        Settings.Default["downloadPath"] = this.downloadPath;
                        Settings.Default.Save();
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

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarLoadingSite.Hide();
            hasWebsiteBeenLoaded = true;
            lblNome.Text = programa.getNome();
            lblNome.Show();
        }

        #region txtUrl text events, which starts the background worker to get the media info
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
        #endregion

        private void timerDownload_Tick(object sender, EventArgs e)
        {
            progressBarDownloadStatus.Value = getPrograssBarSize();
        }

        //gets the size of the downloaded content and 
        //returns how much it has downloaded
        private int getPrograssBarSize()
        {
            lblStatus.Show();
            lblStatus.BringToFront();

            long currentSize = 0;

            try
            {
                FileInfo info = new FileInfo(downloadPath + "\\" + programa.getNomeFormatado() + programa.getFileType());
                currentSize = info.Length;
            }
            catch (Exception)
            {

            }

            lblStatus.Text = (currentSize * Math.Pow(1024, -2)).ToString("0.##") + "MB/" + (programa.getSize() * Math.Pow(1024, -2)).ToString("0.##") + "MB";

            return (int)((currentSize * 100) / programa.getSize());
        }

        /**
         * Downloads website and searches for the media link.
         * Also grabs the name of the media and the episode.
         */
        private void initializePrograma(object sender, DoWorkEventArgs e)
        {
            hasWebsiteBeenLoaded = false;

            this.url = txtUrl.Text;
            string pageContent = null;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(txtUrl.Text);
                HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();
                using (StreamReader sr = new StreamReader(myres.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1")))
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

                    //get the media size
                    WebClient downloadSize = new WebClient();
                    downloadSize.OpenRead(fileURL);
                    long size_bytes = Convert.ToInt64(downloadSize.ResponseHeaders["Content-Length"]);

                    this.programa = new Programa(nome, episodio, fileURL, size_bytes);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {

                }
                MessageBox.Show(ex.Message);
            }
        }
    }
}
