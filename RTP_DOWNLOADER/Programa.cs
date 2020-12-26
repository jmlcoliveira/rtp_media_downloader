using System.Linq;

namespace RTP_DOWNLOADER
{
    public class Programa
    {
        private string nome, episodio, fileURL, fileType;
        private long size;

        public Programa(string nome, string episodio, string file, long size)
        {
            this.nome = nome/*.Replace(" ", "_")*/;
            this.episodio = episodio/*.Replace(" ", "_")*/;
            this.fileURL = file;
            fileType = "." + fileURL.Split('.').Last();
            this.size = size;
        }

        public string getFileType()
        {
            return fileType;
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

        public long getSize()
        {
            return size;
        }

        public string getComando()
        {
            return $"Streamlink --http-header \"User-Agent=xxxxx\" --http-header \"Referer=xxxxx\" \"{fileURL}\" best --output \"{episodio + "_" + nome}.mp4\"";
        }
    }
}
