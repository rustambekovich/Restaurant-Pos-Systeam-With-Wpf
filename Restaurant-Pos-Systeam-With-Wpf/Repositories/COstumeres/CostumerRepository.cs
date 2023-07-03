using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Costumeres;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Repositories.COstumeres
{
    public class CostumerRepository : ICostumer
    {
        private readonly NpgsqlConnection _connection;

        public CostumerRepository()
        {
            _connection = new NpgsqlConnection(ConstanDb.DB_CONNECTIONSTRING);
        }
        public async Task<int> CreatedAtAsync(Costumer entity)
        {
            try
            {

                await _connection.OpenAsync();
                //string q = $"INSERT INTO public.order_items(\r\n\t \"Product_id\", quantity, price)\r\n\tVALUES ({entity.ProductID}, {entity.Quantity}, {entity.Price});";

                string query = $"INSERT INTO public.\"Costumer\"(name, TableId) VALUES ('Guest', {entity.TableId});";
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

        public Task<IList<Costumer>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public async Task<Costumer> GetByIdAsync(long id)
        {
            try
            {
                Costumer list = new Costumer();


                await _connection.OpenAsync();


                string query = $"Select \"Constumer_id\" From public.\"Costumer\" where tableid = {id}";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            list.Id = reader.GetInt64(0);
                        }
                    }

                }
                return list;
            }
            catch
            {
                Costumer costumer = new Costumer();
                return costumer;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<int> UpdatedAtAsync(long id, Costumer entity)
        {
            throw new NotImplementedException();
        }
    }
}
