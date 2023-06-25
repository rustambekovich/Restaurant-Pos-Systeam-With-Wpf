using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Productes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Repositories.Productes;

public class ProductRepository : IProductRepository
{
    private readonly NpgsqlConnection _connection;

    public ProductRepository()
    {
        _connection = new NpgsqlConnection(ConstanDb.DB_CONNECTIONSTRING);
    }

    public Task<int> Count()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreatedAtAsync(Product entity)
    {
        try
        {

            await _connection.OpenAsync();
            string query = "INSERT INTO public.\"Products\"(name, description, price, catigory_id, imagepath) VALUES (@name, @description, @price, @catigory_id, @imagepath);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", entity.Name);
                command.Parameters.AddWithValue("description", entity.Description);
                command.Parameters.AddWithValue("price", entity.Price);
                command.Parameters.AddWithValue("catigory_id", entity.cotigory_id);
                command.Parameters.AddWithValue("imagepath", entity.ImagePath);
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

    public Task<int> DeletedAtAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeletedBynameAtAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        try
        {

            var list = new List<Product>();

            await _connection.OpenAsync();


            string query = $"SELECT * FROM public.\"Products\" ORDER BY \"Producr_id\" ASC ;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var item = new Product();
                        item.Id = reader.GetInt64(0);
                        item.Name = reader.GetString(1);
                        item.Description = reader.GetString(2);
                        item.Price = reader.GetFloat(3);
                        item.cotigory_id = reader.GetInt64(4);
                        item.ImagePath = reader.GetString(5);
                        list.Add(item);
                    }
                }

            }
            return list;
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Product> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdatedAtAsync(long id, Product entity)
    {
        throw new NotImplementedException();
    }

    //public async Task<int> CreatedAtAsync(Category entity)
    //{
    //    try
    //    {

    //        await _connection.OpenAsync();
    //        string query = "INSERT INTO public.\"Product\"(name, description, price, catigory_id, imagepath) VALUES (@name, @description, @price, @catigory_id, @imagepath);";
    //        await using (var command = new NpgsqlCommand(query, _connection))
    //        {
    //            command.Parameters.AddWithValue("name", entity.Name);
    //            var dbrresult = await command.ExecuteNonQueryAsync();
    //            return dbrresult;
    //        }
    //    }
    //    catch
    //    {
    //        return 0;
    //    }
    //    finally
    //    {
    //        await _connection.CloseAsync();
    //    }
    //}


}
