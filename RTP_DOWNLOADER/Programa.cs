using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTP_DOWNLOADER
{
    public class Programa
    {
        private string nome, episodio, dash;

        public Programa(string nome, string episodio, string dash)
        {
            this.nome = nome.Replace(" ", "_");
            this.episodio = episodio.Replace(" ", "_");
            this.dash = dash;
        }

        public string getNome()
        {
            return nome;
        }

        public string nEpisodio()
        {
            return episodio;
        }

        public string getDash()
        {
            return dash;
        }

        public string getComando()
        {
            return $"Streamlink --http-header \"User-Agent=xxxxx\" --http-header \"Referer=xxxxx\" \"{dash}\" best --output \"{episodio + "_" + nome}.mp4\"";
        }
    }
}
