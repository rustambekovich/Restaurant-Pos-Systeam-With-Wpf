using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Repositories.OrderIteames
{
    
    public class OrderIteamRepository : IOrderIteam
    {
        private readonly NpgsqlConnection _connection;

        public OrderIteamRepository()
        {
            _connection = new NpgsqlConnection(ConstanDb.DB_CONNECTIONSTRING);
        }
        public async Task<int> CreatedAtAsync(Domans.Entities.OrderIteam entity)
        {
            try
            {

                await _connection.OpenAsync();

                //string q = $"INSERT INTO public.order_items(\r\n\t \"Product_id\", quantity, price)\r\n\tVALUES ({entity.ProductID}, {entity.Quantity}, {entity.Price});";
                string queryT = $"WITH updated_rows AS (UPDATE public.order_items " +
                               $"SET quantity = quantity + 1 WHERE \"Product_id\" = {entity.ProductID} and order_id = {entity.OrderId} RETURNING *) " +
                               $"INSERT INTO public.order_items (\"Product_id\", quantity, price, order_id) " +
                               $"SELECT {entity.ProductID}, {entity.Quantity}, {entity.Price.ToString(CultureInfo.InvariantCulture)}, {entity.OrderId} WHERE NOT EXISTS (SELECT 1 FROM updated_rows );";



                string query = $"WITH updated_rows AS (UPDATE public.order_items  " +
                            $"SET quantity = quantity + 1 WHERE \"Product_id\" = {entity.ProductID} and order_id = {entity.OrderId}  RETURNING *) " +
                            $"INSERT INTO public.order_items (\"Product_id\", quantity, price, order_id) " +
                            $"SELECT {entity.ProductID}, {entity.Quantity}, {entity.Price}, {entity.OrderId} WHERE NOT EXISTS (SELECT 1 FROM updated_rows );";
                await using (var command = new NpgsqlCommand(queryT, _connection))
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

        public async Task<int> DeletedAtALlItemByIdAsync(long id)
        {
            try
            {
                var list = new List<Category>();
                await _connection.OpenAsync();
                if (_connection.State == System.Data.ConnectionState.Open)
                    await _connection.CloseAsync();
                await _connection.OpenAsync();
                string query = $"DELETE FROM public.order_items WHERE \"order_id\" = {id};";
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

        public async Task<int> DeletedAtAsync(long id)
        {
            try
            {
                var list = new List<Category>();
                await _connection.OpenAsync();
                if (_connection.State == System.Data.ConnectionState.Open)
                    await _connection.CloseAsync();
                await _connection.OpenAsync();
                string query = $"WITH deleted_items AS (DELETE FROM public.order_items  WHERE \"Product_id\" = {id} AND quantity = 1  RETURNING *) UPDATE public.order_items SET quantity = quantity - 1 WHERE \"Product_id\" = {id} AND quantity > 1;";
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

        public Task<int> DeletedBynameAtAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<OrderIteam>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderIteam> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                OrderIteam orderIteam = new OrderIteam();
                string query = $"select order_id FROM public.order_items  WHERE \"Product_id\" = {id};";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            orderIteam.OrderId = reader.GetInt64(0);
                        }
                    }
                }
                return orderIteam;
            }
            catch
            {
                OrderIteam order = new OrderIteam();

                return order;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<decimal> TootalPriceAllAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                decimal res = 0;
                string query = $"SELECT SUM(quantity * price)  FROM order_items WHERE order_id = {id};";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            res = Convert.ToDecimal(reader.GetDouble(0));
                        }
                    }
                }
                return res;
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

        public Task<int> UpdatedAtAsync(long id, Domans.Entities.OrderIteam entity)
        {
            throw new NotImplementedException();
        }
    }
}
