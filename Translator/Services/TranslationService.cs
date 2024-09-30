// File Path: Services/TranslationService.cs
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web;

namespace MauiApp2.Services
{
    public class TranslationService
    {

        public async Task<string> TranslateTextAsync(string text, string sourceLanguage, string targetLanguage)
        {
            var client = new HttpClient();
            text=HttpUtility.UrlEncode(text);
            string TranslationApiUrl1 = $"https://655.mtis.workers.dev/translate?text={text}&source_lang={sourceLanguage}&target_lang={targetLanguage}";
            var response = await client.GetAsync(TranslationApiUrl1);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(jsonResponse);
            return json["response"]["translated_text"].ToString();
        }
    }
}
