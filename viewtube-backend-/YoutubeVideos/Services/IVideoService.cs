using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeVideos.Models;

namespace YoutubeVideos.Services
{
    public interface IVideoService
    {
        Task<YoutubeVideoDetails> GetPopularVideos();
        Task<YoutubeVideoDetails> GetVideosByCategory(string videoCategoryId);
        Task<YoutubeVideoDetails> SearchVideos(string text);
        Task<YoutubeVideoDetails> SearchVideoById(string id);
    }
}