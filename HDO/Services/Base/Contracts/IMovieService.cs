using Core.Helpers;
using Models;
using Models.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Base.Contracts
{
    public interface IMovieService : IBaseDataService
    {
        Task<OperationResult> Create(MovieInputModel Model);
        Task<OperationResult> Delete(int id);
        Task<OperationResult> Update(MovieInputModel Model);

        IAsyncEnumerable<Movie> GetByCategoryAsync(int id);
        IAsyncEnumerable<Movie> GetMoviesAsync(int count);

        IAsyncEnumerable<Movie> GetRatedMoviesAsync(int count);
        IAsyncEnumerable<Movie> GetPopularMoviesAsync(int count);
        IAsyncEnumerable<Movie> GetNewestMoviesAsync(int count);

        IAsyncEnumerable<Movie> GetMovieByIdAsync(int id);
        IAsyncEnumerable<Movie> GetSimilarMoviesAsync(string title, int catId);

        IQueryable<Movie> GetAllAsNoTracking();
        Task<Movie> GetByIdAsync(int id);
    }
}
