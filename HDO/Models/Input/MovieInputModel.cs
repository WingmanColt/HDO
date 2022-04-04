using System;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Input
{
    public class MovieInputModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string URL { get; set; }
        public string ThumbnailPath { get; set; }
        public string WallpaperPath { get; set; }
        public string TrailerPath { get; set; }
        public int Rating { get; set; }
        public int VotedUsers { get; set; }
        public int Views { get; set; }
        public string CategoryName { get; set; }
        public int Runtime { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime DateOfRelease { get; set; }
        public string UserId { get; set; }

        }
}
