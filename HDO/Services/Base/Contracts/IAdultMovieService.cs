using Core.Helpers;
using Models;
using Models.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Base.Contracts
{
    public interface IAdultMovieService : IBaseDataService
    {
        Task<OperationResult> Create(AdultMovieInputModel Model);
        Task<OperationResult> Delete(int id);
        Task<OperationResult> Update(AdultMovieInputModel Model);

        IAsyncEnumerable<AdultMovie> GetByCategoryAsync(string sysName);
        IAsyncEnumerable<AdultMovie> GetMoviesAsync(int count);

        IAsyncEnumerable<AdultMovie> GetRatedMoviesAsync(int count);
        IAsyncEnumerable<AdultMovie> GetPopularMoviesAsync(int count);
        IAsyncEnumerable<AdultMovie> GetNewestMoviesAsync(int count);

        IAsyncEnumerable<AdultMovie> GetMovieByIdAsync(int id);
        IAsyncEnumerable<AdultMovie> GetSimilarMoviesAsync(string title, string catSysName);

        IQueryable<AdultMovie> GetAllAsNoTracking();
        Task<AdultMovie> GetByIdAsync(int id);
    }
}
