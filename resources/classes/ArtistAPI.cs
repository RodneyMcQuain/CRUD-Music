using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net;

namespace musicP.resources.classes
{
    public class ArtistAPI
    {
        public static async Task<HttpResponseMessage> GetArtist()
        {
            Debug.WriteLine("fuck");

            Uri uri = new Uri("https://api.twitch.tv/kraken/streams/?game=Super%20Smash%20Bros.%20Melee");
            HttpClient client = new HttpClient();
            string apiKey = "e5579fbf0u0374vm05153irzz4qmnk";
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + apiKey);
            

             /*HttpClient client = new HttpClient();
             Uri uri = new Uri("https://api.discogs.com/artists/108713");
             string apiKey = "HpEQRDOByvPXorfrQsHJ";
             client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + apiKey); */

            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Client-ID", apiKey);
            //await client.SendAsync(request);

            var request = WebRequest.Create("https://api.twitch.tv/kraken/streams/?game=Super%20Smash%20Bros.%20Melee") as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + apiKey);

            // Get response here
            var response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Debug.WriteLine("fuck");
            }

            HttpResponseMessage result = await client.GetAsync(uri);
            //validate here
            Debug.WriteLine("fuck");
            if (result.IsSuccessStatusCode)
            {
           //     string response = await result.Content.ReadAsStringAsync();
            //    Debug.WriteLine("fuck" + response);
               // dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
              //  Debug.WriteLine(data.streams.display_name);
               // Console.WriteLine(data.streams.display_name);
            } else
            {
                Debug.WriteLine("api call aborted");
            }

            return result;
        }
    }
}