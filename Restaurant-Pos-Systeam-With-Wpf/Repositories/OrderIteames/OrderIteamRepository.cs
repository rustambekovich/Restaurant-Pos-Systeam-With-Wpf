using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
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
                string query = $"INSERT INTO public.order_items(\r\n\t \"Product_id\", quantity, price)\r\n\tVALUES ({entity.ProductID}, {entity.Quantity}, {entity.Price});";
                string q = "INSERT INTO public.\"Products\"(name, description, price, catigory_id, imagepath) VALUES (@name, @description, @price, @catigory_id, @imagepath);";
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

        public Task<int> DeletedAtAsync(long id)
        {
            throw new NotImplementedException();
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
