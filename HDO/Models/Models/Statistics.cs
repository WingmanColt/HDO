using Microsoft.AspNetCore.Identity;
using Models.Input;

namespace Models
{
    public class Statistics : BaseModel
    {
        public int MoviesCount { get; set; }

        public void Update(StatisticInputModel Model)
        {
            Id = Model.Id;
            MoviesCount = Model.MoviesCount;
        }
     }
}
