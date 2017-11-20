using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;

namespace MovieDatabase.Models
{
    public class MovieApiSearch
    {
        public static async Task<MovieApi> GetMovie(string imdbNumber)
        {
            string apiUrl = " http://www.omdbapi.com/?i=";
            string apiKey = "6bce83a9";
            using (var client = new HttpClient())
            {
                string repUrl = apiUrl + imdbNumber + "&apkikey=" + apiKey;
                HttpResponseMessage response = await client.GetAsync(repUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var rootResult = JsonConvert.DeserializeObject<MovieApi>(result);
                    return rootResult;
                }

                else
                {
                    return null;
                }
            }
        }
    }
}