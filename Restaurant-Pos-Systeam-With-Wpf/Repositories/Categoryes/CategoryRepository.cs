using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Categories;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
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

    public async Task<int> DeletedAtAsync(long id)
    {
        try
        {
            _connection.Open();
            string query = $"Delete FROM \"Category\" WHERE Category_id = {id};";
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
            _connection.Close();
        }
    }

    public async Task<int> DeletedAtAsync(string name)
    {
        try
        {
            _connection.Open();
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
            _connection.Close();
        }
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            
            
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    await _connection.OpenAsync();

                }
            var list = new List<Category>();
            string query = $"Select * from \"Category\" \r\nOrder by category_id offset {(@params.PageNumber - 1) * @params.PageSize} limit {@params.PageSize};";
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
            return new List<Category>();
        }
        finally
        {
            await _connection.CloseAsync() ;
        }
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
