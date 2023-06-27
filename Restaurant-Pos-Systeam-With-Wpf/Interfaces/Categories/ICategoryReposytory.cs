using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories
{
    public interface ICategoryReposytory : IRepository<Category, Category>
    {
        public Task<int> Count();
        public Task<IList<Category>> GetAllAsync();

    }
}
