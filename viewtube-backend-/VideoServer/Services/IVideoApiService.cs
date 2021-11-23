using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoServer.Models;

namespace VideoServer.Services
{
    public interface IVideoApiService
    {
        Task<List<VideoModel>> GetPopularVideos();
    }
}
