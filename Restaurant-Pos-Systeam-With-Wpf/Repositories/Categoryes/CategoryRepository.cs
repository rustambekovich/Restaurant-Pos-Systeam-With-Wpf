using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Repositories.Categoryes;

public class CategoryRepository : ICategoryReposytory
{
    private readonly NpgsqlConnection _connection;

    public CategoryRepository()
    {
        _connection = new NpgsqlConnection(ConstanDb.DB_CONNECTIONSTRING);
    }
    public Task<int> Count()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreatedAtAsync(Category entity)
    {
        try
        {
            _connection.Open();
            string query = "Insert Into \"Category\"(name) values (@name);";
            await using(var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", entity.Name);
                var dbrresult = await command.ExecuteNonQueryAsync();
                return dbrresult;
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            _connection.Close();
        }

    }

    public Task<int> DeletedAtAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        throw new System.NotImplementedException();
    }

    public Task<Category> GetByIdAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdatedAtAsync(long id, Category entity)
    {
        throw new System.NotImplementedException();
    }
}
