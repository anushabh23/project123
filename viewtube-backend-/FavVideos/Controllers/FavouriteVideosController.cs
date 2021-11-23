using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavVideos.Models;
using FavVideos.Services;

namespace FavVideos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteVideosController : ControllerBase
    {
        //private readonly IFavVideosRepository repo;
        private readonly IFavVideoService service;
        public FavouriteVideosController(IFavVideoService _service)
        {
            this.service = _service;
        }

        [HttpGet("{userId}")]
        public IActionResult GetVideosList(int userId)
        {
            var favVideoList = service.GetFavVideoList(userId);
            return StatusCode(200, favVideoList);
        }

        [HttpPost("delete")]
        public IActionResult DeleteVideo(FavVideo favVideo)
        {
            service.DeleteFavVideo(favVideo);
            //return favVideo;
            return Ok("Deleted");
        }

        [HttpPost("add")]
        public IActionResult AddVideo(FavVideo favVideo)
        {
            if (ModelState.IsValid)
            {
                service.AddFavVideo(favVideo);
                //return favVideo;
                return Ok("created");
            }
            else
            {
                return BadRequest(ModelState);
            }
                
            
        }

    }
}
