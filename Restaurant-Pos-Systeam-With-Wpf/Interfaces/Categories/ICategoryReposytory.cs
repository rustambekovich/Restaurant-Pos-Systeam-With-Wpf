using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories
{
    public interface ICategoryReposytory : IRepository<Category, Category>
    {
        public Task<int> Count();
    }
}
