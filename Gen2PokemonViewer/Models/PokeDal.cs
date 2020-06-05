using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Gen2PokemonViewer.Models
{
    public class PokeDal
    {
        public string GetAPIJson(string endpoint, int id)
        {
            string url = $"https://swapi.dev/api/{endpoint}/{id}/";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }

        public Pokemon GetPokemonById(int id)
        {
            string pokeData = GetAPIJson("pokemon", id);
            Pokemon p = JsonConvert.DeserializeObject<Pokemon>(pokeData);
            return p;
        }
    }
}
