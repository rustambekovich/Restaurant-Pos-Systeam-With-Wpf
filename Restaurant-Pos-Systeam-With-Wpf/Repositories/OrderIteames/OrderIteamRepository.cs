using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.OrderIteames;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
                string sql = $"WITH updated_rows AS (UPDATE public.order_items SET quantity = quantity + 1 WHERE \"Product_id\" = {entity.ProductID} RETURNING *) " +
                             $"INSERT INTO public.order_items (\"Product_id\", quantity, price) " +
                            $"SELECT {entity.ProductID}, {entity.Quantity}, {entity.Price} WHERE NOT EXISTS (SELECT 1 FROM updated_rows);";
                string query = $"WITH updated_rows AS (UPDATE public.order_items  SET quantity = quantity + 1 WHERE \"Product_id\" = {entity.ProductID}  RETURNING *) INSERT INTO public.order_items (\"Product_id\", quantity, price) SELECT {entity.ProductID}, {entity.Quantity}, {entity.Price} WHERE NOT EXISTS (SELECT 1 FROM updated_rows );";
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

        public async Task<int> DeletedAtALlItemAsync()
        {
            try
            {
                var list = new List<Category>();
                await _connection.OpenAsync();
                if (_connection.State == System.Data.ConnectionState.Open)
                    await _connection.CloseAsync();
                await _connection.OpenAsync();
                string query = $"DELETE FROM public.order_items WHERE \"Product_id\" > 0;";
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

        public Task<IList<Domans.Entities.OrderIteam>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<Domans.Entities.OrderIteam> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatedAtAsync(long id, Domans.Entities.OrderIteam entity)
        {
            throw new NotImplementedException();
        }
    }
}
