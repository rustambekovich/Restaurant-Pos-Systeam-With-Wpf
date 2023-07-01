using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.ViewModeles;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using Restaurant_Pos_Systeam_With_Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Repositories.ViewModeles
{
    public class ViewModelRepository : IOrderItemView
    {
        private readonly NpgsqlConnection _connection;

        public ViewModelRepository()
        {
            _connection = new NpgsqlConnection(ConstanDb.DB_CONNECTIONSTRING);
        }
        public Task<int> CountById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreatedAtAsync(OrderItemViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletedAtAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletedBynameAtAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<OrderItemViewModel>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                var list = new List<OrderItemViewModel>();

                if (_connection.State == System.Data.ConnectionState.Open)
                    await _connection.CloseAsync();
                await _connection.OpenAsync();



                string query = $"SELECT  quantity,\"Product_id\", name, price FROM public.orderitemviewmodel13 ORDER BY \"Product_id\" ASC;";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = new OrderItemViewModel();
                            item.Quantity = reader.GetInt64(0);
                            item.Product_id = reader.GetInt64(1);
                            item.ProductName = reader.GetString(2);
                            item.Price = float.Parse(reader.GetDouble(3).ToString(),CultureInfo.InvariantCulture.NumberFormat);
                            item.UnitPrice = item.Price;
                            item.Price = item.UnitPrice * item.Quantity;

                            list.Add(item);
                        }
                    }

                }
                return list;
            }
            catch
            {
                return new List<OrderItemViewModel>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<OrderItemViewModel> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatedAtAsync(long id, OrderItemViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
