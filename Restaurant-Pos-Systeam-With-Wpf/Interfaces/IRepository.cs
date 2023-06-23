

using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Interfaces;

public interface IRepository<TEntity, TViewModel> 
{
    public Task<int> CreatedAtAsync(TEntity entity);
    public Task<int> UpdatedAtAsync(long id, TEntity entity);
    public Task<int> DeletedAtAsync(long id);
    public Task<int> DeletedBynameAtAsync(string name);
    public Task<TViewModel> GetByIdAsync(long id);
    public Task<IList<TViewModel>> GetAllAsync(PaginationParams @params);
}
