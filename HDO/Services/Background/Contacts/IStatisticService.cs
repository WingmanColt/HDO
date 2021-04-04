using Core.Helpers;
using Models.Input;
using System.Threading.Tasks;

namespace Services.Background.Contracts
{

    public interface IStatisticService
    {
        Task<OperationResult> Update(StatisticInputModel viewModel);


    }
}
