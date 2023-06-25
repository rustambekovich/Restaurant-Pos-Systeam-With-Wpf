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

            await _connection.OpenAsync();
            string query = "Insert Into \"Category\"(name) values (@name);";
            await using (var command = new NpgsqlCommand(query, _connection))
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
            await _connection.CloseAsync();
        }

    }

    public async Task<int> DeletedAtAsync(long id)
    {
        try
        {
            var list = new List<Category>();
            await _connection.OpenAsync();
            if (_connection.State == System.Data.ConnectionState.Open)
                await _connection.CloseAsync();
            await _connection.OpenAsync();
            string query = $"Delete FROM \"Category\" WHERE category_id = {id};";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
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
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeletedBynameAtAsync(string name)
    {
        try
        {
            var list = new List<Category>();
            await _connection.OpenAsync();
            if (_connection.State == System.Data.ConnectionState.Open)
                await _connection.CloseAsync();
            await _connection.OpenAsync();
            string query = $"Delete FROM \"Category\" WHERE name = '{name}';";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
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
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var list = new List<Category>();
        try
        {


            await _connection.OpenAsync();


            string query = $"Select * from \"Category\" \r\nOrder by category_id;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var category = new Category();
                        category.Id = reader.GetInt64(0);
                        category.Name = reader.GetString(1);
                        list.Add(category);
                    }
                }

            }
            return list;
        }
        catch
        {
            return list;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Category> GetByIdAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> UpdatedAtAsync(long id, Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.\"Category\" SET name= '{entity.Name}'\r\n\tWHERE category_id= {id};";
            await using (var command = new NpgsqlCommand(query, _connection))
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
            await _connection.CloseAsync();
        }
    }
}
