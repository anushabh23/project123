using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VideoServer.Models;

namespace VideoServer.Services
{
    public class VideoApiService : IVideoApiService
    {
        private readonly HttpClient _httpClient;

        public VideoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<VideoModel>> GetPopularVideos()
        {
            var apiKey = "AIzaSyB2xtEZ1PWhmbPAPbyC6LtapaubOGdWhcI";
            string ApiUrl = $"?part=snippet&chart=mostPopular&regionCode=in&maxResults=10&key={apiKey}";
            var result = new List<VideoModel>();
            var response = await _httpClient.GetAsync(ApiUrl);
            var stringResponse = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {

                result = JsonConvert.DeserializeObject<List<VideoModel>>(stringResponse);


            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
            ;

        }

    }
}
