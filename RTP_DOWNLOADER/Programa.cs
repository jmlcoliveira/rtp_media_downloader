using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTP_DOWNLOADER
{
    public class Programa
    {
        private string nome, episodio, fileURL;

        public Programa(string nome, string episodio, string file)
        {
            this.nome = nome/*.Replace(" ", "_")*/;
            this.episodio = episodio/*.Replace(" ", "_")*/;
            this.fileURL = file;
        }

        public string getNome()
        {
            return nome;
        }

        public string getNomeFormatado()
        {
            return nome.Replace(" ", "_").Replace("?", "_");
        }

        public string getEpisodio()
        {
            return episodio;
        }

        public string getFileURL()
        {
            return fileURL;
        }

        public string getComando()
        {
            return $"Streamlink --http-header \"User-Agent=xxxxx\" --http-header \"Referer=xxxxx\" \"{fileURL}\" best --output \"{episodio + "_" + nome}.mp4\"";
        }
    }
}
