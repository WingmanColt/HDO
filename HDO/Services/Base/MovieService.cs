using Core.Helpers;
using Data.Repositories.Contracts;
using HDO.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Input;
using Services.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Base
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;


        public MovieService(IRepository<Movie> movieRepository, BaseDbContext _context)
        {
            _movieRepository = movieRepository;
           // SeedTest(_context);
        }

        public async Task<OperationResult> Create(MovieInputModel Model)
        {
            var entity = new Movie();
            entity.Update(Model);

            await _movieRepository.AddAsync(entity);

            var result = await _movieRepository.SaveChangesAsync();
            return result;
        }

        public async Task<OperationResult> Delete(int id)
        {
            if (!(await IsExists(id)))
            {
                return OperationResult.FailureResult("Movie dosen't exists");
            }

            Movie existEntity = await _movieRepository.GetByIdAsync(id);

            _movieRepository.Delete(existEntity);

            var result = await _movieRepository.SaveChangesAsync();
            return result;
        }

        public async Task<OperationResult> Update(MovieInputModel Model)
        {
            if (!(await IsExists(Model.Id)))
            {
                return OperationResult.FailureResult("Movie dosen't exists");
            }

            Movie existEntity = await _movieRepository.GetByIdAsync(Model.Id);

            existEntity.Update(Model);

            _movieRepository.Update(existEntity);

            var result = await _movieRepository.SaveChangesAsync();
            return result;
        }

        public IAsyncEnumerable<Movie> GetMoviesAsync(int count = 0)
        {
            var entity = _movieRepository
                .All()
                .Take(count)
                .AsAsyncEnumerable();

            return entity;
        }
        public IAsyncEnumerable<Movie> GetMovieByIdAsync(int id)
        {
            var entity = GetAllAsNoTracking()
                .Where(x => x.Id == id)
                .AsAsyncEnumerable();

            return entity;
        }
        public IAsyncEnumerable<Movie> GetRatedMoviesAsync(int count = 0)
        {
            var entity = GetAllAsNoTracking()
                .OrderBy(x => x.Rating)
                .Take(count)
                .AsAsyncEnumerable();


            return entity;
        }
        public IAsyncEnumerable<Movie> GetNewestMoviesAsync(int count = 0)
        {
            var entity = GetAllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Take(count)
                .AsAsyncEnumerable();

            return entity;
        }
        public IAsyncEnumerable<Movie> GetPopularMoviesAsync(int count = 0)
        {
            var entity = GetAllAsNoTracking()
                .OrderBy(x => x.Views)
                .Take(count)
                .AsAsyncEnumerable();

            return entity;
        }
        public IAsyncEnumerable<Movie> GetByCategoryAsync(int id)
        {
            var entity = GetAllAsNoTracking()
                .Where(x => x.CategoryId == id)
                .OrderByDescending(x => x.Rating)
                .Take(20)
                .AsAsyncEnumerable();

            return entity;
        }

        public IAsyncEnumerable<Movie> GetSimilarMoviesAsync(string title, int catId)
        {
            var entity = GetAllAsNoTracking()
                .Where(x => (x.CategoryId == catId) || (x.Title == title))
                .AsAsyncEnumerable();

            return entity;
        }
        public IQueryable<Movie> GetAllAsNoTracking()
        {
            return _movieRepository.AllAsNoTracking().AsQueryable();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            var entity = await _movieRepository.GetByIdAsync(id);
            return entity;
        }
        private async Task<bool> IsExists(int id)
        {
            var result = await _movieRepository.AllAsNoTracking().AnyAsync(x => x.Id == id);
            return result;
        }
        public void SeedTest(BaseDbContext dbContext)
        {
            var test = new List<Movie>();
            Random r = new Random();
            for (int i = 0; i < 500; i++)
            {
                test = new List<Movie>
                {
                new Movie
                {
                 Title = $"Movie - #{i}",
                 CategoryId = r.Next(1, 13),
                 About = "HDO HDO HDO HDO HDO HDO",
                 URL = "yg.mp4",
                 ThumbnailPath = "https://image.tmdb.org/t/p/original//4EYPN5mVIhKLfxGruy7Dy41dTVn.jpg",
                 WallpaperPath = "https://wallpapercave.com/wp/wp1911668.png",
                 TrailerPath = "https://www.youtube.com/watch?v=Cp4Rxh1ZqzA",
                 Runtime = r.Next(60, 140),
                 Views = r.Next(0, 10040),
                 VotedUsers = r.Next(0, 10040),
                 Rating = r.Next(0, 10)
            }

               };
                dbContext.Movie.AddRange(test);
            }

            dbContext.SaveChanges();
        }


    }
}
