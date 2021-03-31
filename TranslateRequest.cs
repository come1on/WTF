using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WTF_WIKI_TRANS_FUN
{
    public class TranslateRequest
    {
        private readonly HttpClient _client = new HttpClient();

        public TranslateRequest()
        {
            _client.BaseAddress = new Uri("https://api.funtranslations.com/translate/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<TranslateResponse> Translate(string tText, string language)
        {
            HttpResponseMessage response = await _client.GetAsync($"{language}.json/?text={tText}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<TranslateResponse>();
            else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                throw new TooManyRequestsException("Das hat nicht geklappt. Du hast zu viel angefragt warte mal");

            return null;
        }

        public async Task<TranslateResponse> SearchTextAsync(string text, string language)
        {
            return await Translate(text, language);

        }
    }
}