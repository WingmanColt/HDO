using Ardalis.GuardClauses;
using System;
using Models.Input;

namespace Models
{
    public class Movie : BaseModel
    {
        public string Title { get; set; }
        public string About { get; set; }
        public string URL { get; set; }
        public string ThumbnailPath { get; set; }
        public string WallpaperPath { get; set; }
        public string TrailerPath { get; set; }
        public int Rating { get; set; }
        public int VotedUsers { get; set; }
        public int Views { get; set; }
        public int CategoryId { get; set; }
        public int Runtime { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string UserId { get; set; }

        public void Update(MovieInputModel Model)
        {
            Id = Model.Id;

            Guard.Against.NullOrEmpty(Model.Title, nameof(Model.Title));
            Title = Model.Title;

            Guard.Against.NullOrEmpty(Model.About, nameof(Model.About));
            About = Model.About;

            Guard.Against.NullOrEmpty(Model.URL, nameof(Model.URL));
            URL = Model.URL;

            Guard.Against.NullOrEmpty(Model.ThumbnailPath, nameof(Model.ThumbnailPath));
            ThumbnailPath = Model.ThumbnailPath;

            Guard.Against.NullOrEmpty(Model.WallpaperPath, nameof(Model.WallpaperPath));
            WallpaperPath = Model.WallpaperPath;

            Guard.Against.NullOrEmpty(Model.TrailerPath, nameof(Model.TrailerPath));
            TrailerPath = Model.TrailerPath;

            Guard.Against.Negative(Model.CategoryId, nameof(Model.CategoryId));
            CategoryId = Model.CategoryId;

            Guard.Against.Negative(Model.Runtime, nameof(Model.Runtime));
            Runtime = Model.Runtime;

            //Guard.Against.NullOrEmpty(Model.UserId, nameof(Model.UserId));
            UserId = Model.UserId;
        }
        }
}
