using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeVideos.Services;
using YoutubeVideos.Models;

namespace YoutubeVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<IActionResult> VideosGet()
        {
            var videos = await _videoService.GetPopularVideos();
            return (IActionResult)videos;
        }
        [HttpGet("category/{cid}")]
        public async Task<IActionResult> VideosGetByCategory(string videoCategoryId)
        {
            var videos = await _videoService.GetVideosByCategory(videoCategoryId);
            return (IActionResult)videos;
        }
        [HttpGet("search/{text}")]
        public async Task<IActionResult> VideosSearchById(string text)
        {
            var videos = await _videoService.SearchVideos(text);
            return (IActionResult)videos;
        }
        [HttpGet("search/{vid}")]
        public async Task<IActionResult> VideosSearch(string videoId)
        {
            var videos = await _videoService.SearchVideoById(videoId);
            return (IActionResult)videos;
        }


    }
}