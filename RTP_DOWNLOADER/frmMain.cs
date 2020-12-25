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
        private Process process;
        private readonly string urlValidation = "www.rtp.pt/play";
        private Programa programa;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!Helper.checkInstalled("Streamlink"))
            {
                MessageBox.Show("Required program missing!");
                var currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Process proc = Process.Start(currentDirectory + "\\streamlink-2.0.0.exe");
                proc.WaitForExit();
            }
            this.downloadPath = ConfigurationManager.AppSettings["lastSaveLocation"];
            txtPath.Text = this.downloadPath;
            txtPath.Enabled = false;
            panelProgess.Hide();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "" || downloadPath == "")
            {
                if (txtUrl.Text == "")
                    MessageBox.Show("URL não especificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (downloadPath == "")
                    MessageBox.Show("Localização para guardar não especificada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!txtUrl.Text.Contains(urlValidation))
            {
                MessageBox.Show("URL inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            handleDownload();
        }

        private void handleDownload()
        {
            this.process = ExecuteCommand(programa.getComando());


            panelDownload.Hide();
            panelProgess.Show();

            verificarProcesso.Start();

            //MessageBox.Show("Download realizado com sucesso");
        }

        private void verificarProcesso_Tick(object sender, EventArgs e)
        {
            if (process.HasExited)
            {
                verificarProcesso.Stop();

                panelDownload.Show();
                panelProgess.Hide();
                txtUrl.Text = "";
                MessageBox.Show("Download Concluído");
                try
                {
                    Process.Start(this.downloadPath);
                }
                catch (Exception)
                {

                }
            }
        }

        public Process ExecuteCommand(string Command)
        {
            ProcessStartInfo ProcessInfo;

            ProcessInfo = new ProcessStartInfo("powershell.exe", Command);
            ProcessInfo.WorkingDirectory = this.downloadPath;
            ProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;

            return Process.Start(ProcessInfo);
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
                try
                {
                    this.process.CloseMainWindow();
                }
                catch (Exception)
                {

                }

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


                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["lastSaveLocation"].Value = this.downloadPath;
                    config.Save(ConfigurationSaveMode.Modified);

                    ConfigurationManager.RefreshSection("appSettings");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            initializePrograma();
        }

        private void txtUrl_MouseLeave(object sender, EventArgs e)
        {
            initializePrograma();
        }

        private void initializePrograma()
        {
            if (txtUrl.Text.Contains(urlValidation) && txtUrl.Text != this.url)
            {
                this.url = txtUrl.Text;
                string pageContent = null;
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(txtUrl.Text);
                HttpWebResponse myres = (HttpWebResponse)myReq.GetResponse();
                using (StreamReader sr = new StreamReader(myres.GetResponseStream()))
                {
                    pageContent = sr.ReadToEnd();
                }

                if (pageContent.Contains("master.mpd"))
                {
                    int index = pageContent.IndexOf("master.mpd");
                    string dash = pageContent.Substring(0, index).Split('\"').Last() + "master.mpd";
                    index = pageContent.IndexOf("episode-number");
                    string episodio = "0";
                    if (index != -1)
                        episodio = pageContent.Substring(index).Split('>', '<')[1];

                    index = pageContent.IndexOf("vod-title");
                    string nome = "name_not_found";
                    if (index != -1)
                        nome = pageContent.Substring(index).Split('>', '<')[1];

                    this.programa = new Programa(nome, episodio, dash);
                }
            }
        }
    }
}
