using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace VideoDetails
{
    public class SearchVideos
    {

        static async Task<List<YouTubeVideoDetails>> Main(string[] args)
        {
            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyB2xtEZ1PWhmbPAPbyC6LtapaubOGdWhcI",

            });

            var searchListRequest = service.Search.List("snippet");
            searchListRequest.Q = "bitcoin"; // Replace with your search term.
            searchListRequest.MaxResults = 10;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            //    List<YouTubeVideoDetails> videos = new List<YouTubeVideoDetails>();

            //    if (searchListResponse != null)
            //         {
            //             YouTubeVideoDetails videoDetails = new YouTubeVideoDetails()
            //             {
            //                 // VideoId = searchListResponse.Items.Id.VideoId,
            //                 // Description = searchListResponse.Snippet.Description,
            //                 // Title = searchListResponse.Snippet.Title,
            //                 // ChannelTitle = searchListResponse.Snippet.ChannelTitle,
            //                 // PublicationDate = searchListResponse.Snippet.PublishedAt
            //             };

            var videoList = new List<YouTubeVideoDetails>();

            foreach (var searchResult in searchListResponse.Items)
            {
                YouTubeVideoDetails videoDetails = new YouTubeVideoDetails()
                {
                    VideoId = searchResult.Id.VideoId,
                    Description = searchResult.Snippet.Description,
                    Title = searchResult.Snippet.Title,
                    ChannelTitle = searchResult.Snippet.ChannelTitle,
                    PublicationDate = searchResult.Snippet.PublishedAt
                };
                videoList.Add(videoDetails);
            }
            //return await Task<List<YouTubeVideoDetails>>;

        }
    }
    public class YouTubeVideoDetails
    {
        public string VideoId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ChannelTitle { get; set; }
        public DateTime? PublicationDate { get; set; }
    }
}