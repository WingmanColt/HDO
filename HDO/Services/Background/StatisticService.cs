using Core.Helpers;
using Data.Repositories.Contracts;
using Models;
using Models.Input;
using Services.Background.Contracts;
using System.Threading.Tasks;

namespace Services.Background
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository<Statistics> _Repository;


        public StatisticService(IRepository<Statistics> Repository)
        {
            _Repository = Repository;
        }

        public async Task<OperationResult> Update(StatisticInputModel viewModel)
        {
            Statistics Entity = await _Repository.GetByIdAsync(viewModel.Id);

            if (Entity is null)
            {
                Entity = new Statistics();
                Entity.Update(viewModel);
                await _Repository.AddAsync(Entity);
            }
            else
            {
                Entity.Update(viewModel);
                _Repository.Update(Entity);
            }

            var result = await _Repository.SaveChangesAsync();
            return result;
        }


        public async Task<Statistics> GetByIdAsync(int id)
        {
            var ent = await _Repository.GetByIdAsync(id);
            return ent;
        }

    }
}
