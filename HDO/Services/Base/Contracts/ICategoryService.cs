using Core.Helpers;
using Models;
using Models.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Base.Contracts
{
    public interface ICategoryService : IBaseDataService
    {
        IAsyncEnumerable<Category> GetTop(int entitiesToShow);
        IQueryable<Category> GetAllAsNoTracking();
        Task<Category> GetByIdAsync(int id);
        IAsyncEnumerable<SelectListModel> GetAllSelectList();
    }
}
