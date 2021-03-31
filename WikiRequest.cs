using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;



namespace WTF_WIKI_TRANS_FUN
{
    
        public class WikiRequest
        {
            private readonly HttpClient _client = new HttpClient();

            public WikiRequest()
            {
                _client.BaseAddress = new Uri("https://en.wikipedia.org/w/api.php");
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }

            private async Task<string> Wikisearch(string tText)
            {
                HttpResponseMessage response = await _client.GetAsync($"?action=opensearch&format=json&search={tText}&namespace=0&limit=1");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    throw new TooManyRequestsException("Das hat nicht geklappt. Du hast zu viel angefragt warte mal");

                return null;
            }

            public async Task<string> SearchTextAsync(string text)
            {
                return await Wikisearch(text);

            }

            
        }
    
}
