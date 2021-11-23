using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavVideos.Models;

namespace FavVideos.Models
{
    public class FavVideosRepository : IFavVideosRepository
    {
        private readonly FavVideosContext _context;
        public FavVideosRepository(FavVideosContext context)
        {
            _context = context;
        }

        public List<FavVideo> GetFavVideoList(int userId)
        {
            var favVideoList = _context.FavVideosTable.Where(v => v.UserId == userId).ToList();
            return favVideoList;
        }
        public FavVideo AddFavVideo(FavVideo favVideo)
        {
            _context.FavVideosTable.Add(favVideo);
            _context.SaveChanges();
            return favVideo;
        }

        public FavVideo DeleteFavVideo(FavVideo favVideo)
        {
            FavVideo favVideoToDelete;
            favVideoToDelete = _context.FavVideosTable.Where(v => v.UserId == favVideo.UserId && v.VideoId == favVideo.VideoId).FirstOrDefault();
            _context.FavVideosTable.Remove(favVideoToDelete);
            _context.SaveChanges();
            return favVideoToDelete;
        }


    }
}
