using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoServer.Services;
using VideoServer.Models;

namespace VideoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoApiService _videoService;
        public VideoController(IVideoApiService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<IActionResult> VideosGet()
        {
            List<VideoModel> videos = new List<VideoModel>();
            List<VideoModel> videoModels = await _videoService.GetPopularVideos();
            videos = videoModels;

            return (IActionResult)videos;

        }

    }
}
