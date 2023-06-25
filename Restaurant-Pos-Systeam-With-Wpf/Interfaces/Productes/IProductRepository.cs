 using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;

public interface IProductRepository : IRepository<Product, Product>
{
    public Task<int> Count();
    public Task<IList<Product>> GetAllByCategoryIdAsync(long id);
}

