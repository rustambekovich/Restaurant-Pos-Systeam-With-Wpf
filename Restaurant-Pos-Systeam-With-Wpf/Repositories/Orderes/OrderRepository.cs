using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Orderes;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Repositories.Orderes
{
    public class OrderRepository : IOrder
    {
        private readonly NpgsqlConnection _connection;

        public OrderRepository()
        {
            _connection = new NpgsqlConnection(ConstanDb.DB_CONNECTIONSTRING);
        }
        public async Task<int> CreatedAtAsync(Order entity)
        {
            try
            {

                await _connection.OpenAsync();
                //string q = $"INSERT INTO public.order_items(\r\n\t \"Product_id\", quantity, price)\r\n\tVALUES ({entity.ProductID}, {entity.Quantity}, {entity.Price});";
                string query = $"INSERT INTO public.\"Orders\"( costumer_id, order_date, total_amount, status, table_id, employee_id) VALUES ( {entity.CostumerID}, '{entity.CreatedAt}', {entity.TotalAmount}, '{entity.Ordertatus.ToString()}', {entity.TableID},{1});";
                string query1 = $"INSERT INTO public.\"Orders\"( costumer_id, order_date, total_amount, status, table_id, employee_id) VALUES ( {entity.CostumerID}, {entity.CreatedAt}, {entity.TotalAmount}, {entity.Ordertatus.ToString()}, {entity.TableID}, {entity.EmployeID});";
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

        public Task<IList<Order>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public async Task<long> GetById(long id)
        {
            

                long n = 0;

                await _connection.OpenAsync();


                string query = $"Select order_id From public.\"Orders\" where table_id = {id} Order by order_id  desc limit 1";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        if(await reader.ReadAsync())
                        {
                            n = reader.GetInt64(0);
                        }
                    }

           
                }
                await _connection.CloseAsync();
                return n;
            
        }

        public  async Task<Order> GetByIdAsync(long id)
        {
            Order order = new Order();

            await _connection.OpenAsync();


            string query = $"Select order_id From public.\"Orders\" where table_id = {id} Order by order_id  desc limit 1";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        order.Id = reader.GetInt64(0);
                    }
                }


            }
            await _connection.CloseAsync();
            return order;
        }

        public async Task<int> UpdatedAtAsync(long id, Order entity)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Orders\"\r\n\tSET  status=@status \r\n\tWHERE order_id = {id} ;";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("status", entity.Ordertatus.ToString());
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
}
