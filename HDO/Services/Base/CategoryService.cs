namespace Services.Base
{
    using Core.Helpers;
    using Data.Repositories.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Services.Base.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryService: ICategoryService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoryService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IAsyncEnumerable<SelectListModel> GetAllSelectList()
        {
            var result = GetAllAsNoTracking()
                    .Select(x => new SelectListModel
                    {
                        Value = x.Id.ToString(),
                        Text = x.Title
                    })
                    .AsAsyncEnumerable();

            return result;
        }
        
        public IAsyncEnumerable<Category> GetTop(int entitiesToShow)
        {
            return GetAllAsNoTracking()
                   .Take(entitiesToShow)
                   .AsAsyncEnumerable();
        }

        public IQueryable<Category> GetAllAsNoTracking()
        {
            return categoriesRepository.AllAsNoTracking().AsQueryable();
        }

        // Seed Categories
        public async Task<OperationResult> SeedCategories()
        {
            if (await GetAllAsNoTracking().AnyAsync())
                return OperationResult.FailureResult("Categories already exists.");

            var lines = await File.ReadAllLinesAsync(@"SeedFiles/Categories.txt");

            for (int i = 1; i <= (lines?.Length - 1); i++)
            {
               var vals1 = lines[i]?.Split('#');

                var category = new Category
                {
                        Title = vals1[0].ToString(),
                        Icon = vals1[1].ToString()
                };
                await categoriesRepository.AddAsync(category);
            }

            var result = await categoriesRepository.SaveChangesAsync();
            return result;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var ent = await categoriesRepository.GetByIdAsync(id);
            return ent;
        }
    }
}