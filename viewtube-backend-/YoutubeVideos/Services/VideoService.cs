using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using YoutubeVideos.Models;


namespace YoutubeVideos.Services
{
    public class VideoService : IVideoService
    {

        public async Task<YoutubeVideoDetails> GetPopularVideos()
        {
            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyB2xtEZ1PWhmbPAPbyC6LtapaubOGdWhcI"
            });

            var request = service.Videos.List("snippet");
            request.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
            request.RegionCode = "in";
            request.MaxResults = 10;

            var results = await request.ExecuteAsync();

            if (results.Items.Count <= 0) Console.WriteLine("No videos");

            var response = new List<YoutubeVideoDetails>();



            foreach (var video in results.Items)
            {
                var youtubevideoDetails = new YoutubeVideoDetails
                {
                    VideoId = video.Id;
            };
            response.Add(youtubevideoDetails);
        }
            return null;
        }

    public async Task<YoutubeVideoDetails> GetVideosByCategory(string videoCategoryId)
    {
        var service = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyB2xtEZ1PWhmbPAPbyC6LtapaubOGdWhcI"
        });

        var request = service.Videos.List("snippet");
        request.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
        request.VideoCategoryId = videoCategoryId;
        request.RegionCode = "in";
        request.MaxResults = 10;

        var results = await request.ExecuteAsync();

        if (results.Items.Count <= 0) Console.WriteLine("No videos");

        foreach (var video in results.Items)
        {
            if (video.Snippet.DefaultAudioLanguage == "hi" || video.Snippet.DefaultAudioLanguage == "en")
            {
                Console.WriteLine($"{video.Snippet.Title} https://www.youtube.com/watch?v={video.Id}");
            }

        }
        return null;
    }
    public async Task<YoutubeVideoDetails> SearchVideos(string text)
    {
        var service = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyB2xtEZ1PWhmbPAPbyC6LtapaubOGdWhcI"
        });

        var searchListRequest = service.Search.List("snippet");
        searchListRequest.Q = text;
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

        var videoList = new List<YoutubeVideoDetails>();

        foreach (var searchResult in searchListResponse.Items)
        {
            YoutubeVideoDetails videoDetails = new YoutubeVideoDetails()
            {
                VideoId = searchResult.Id.VideoId,
                Description = searchResult.Snippet.Description,
                Title = searchResult.Snippet.Title,
                ChannelTitle = searchResult.Snippet.ChannelTitle,
                // PublicationDate = searchResult.Snippet.PublishedAt
            };
            videoList.Add(videoDetails);
        }
        //return await Task<List<YouTubeVideoDetails>>;
        return null;
    }

    public async Task<YoutubeVideoDetails> SearchVideoById(string id)
    {
        var service = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyB2xtEZ1PWhmbPAPbyC6LtapaubOGdWhcI"
        });

        var searchRequest = service.Videos.List("snippet");
        searchRequest.Id = id;

        var searchResponse = await searchRequest.ExecuteAsync();
        var youTubeVideo = searchResponse.Items.FirstOrDefault();
        if (youTubeVideo != null)
        {
            YoutubeVideoDetails videoDetails = new YoutubeVideoDetails()
            {
                VideoId = youTubeVideo.Id,
                Description = youTubeVideo.Snippet.Description,
                Title = youTubeVideo.Snippet.Title,
                ChannelTitle = youTubeVideo.Snippet.ChannelTitle,
                // PublicationDate = youTubeVideo.Snippet.PublishedAt
            };

            // Console.WriteLine(videoDetails.Description);

        }
        return null;
    }
}
}