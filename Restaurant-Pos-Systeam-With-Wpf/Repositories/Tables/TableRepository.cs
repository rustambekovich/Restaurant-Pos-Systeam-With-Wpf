using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Domains.Enums;
using Restaurant_Pos_Systeam_With_Wpf.Domans.Entities;
using Restaurant_Pos_Systeam_With_Wpf.Interfaces.Tables;
using Restaurant_Pos_Systeam_With_Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Pos_Systeam_With_Wpf.Repositories.Tables
{
    public class TableRepository : ITebleRepository
    {
        private readonly NpgsqlConnection _connection;

        public TableRepository()
        {
            _connection = new NpgsqlConnection(ConstanDb.DB_CONNECTIONSTRING);
        }
        public async Task<int> CreatedAtAsync(TableRes entity)
        {
            try
            {

                await _connection.OpenAsync();
                string query = "INSERT INTO public.\"Tables\"(table_number, seating_capacity, status) VALUES ( @table_number, @seating_capacity, @status);";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("table_number", entity.TableNumber);
                    command.Parameters.AddWithValue("seating_capacity", entity.SeatingCapasity);
                    command.Parameters.AddWithValue("status", entity.status.ToString());
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
                await _connection.OpenAsync();
                if (_connection.State == System.Data.ConnectionState.Open)
                    await _connection.CloseAsync();
                await _connection.OpenAsync();

                string query = $"DELETE FROM public.\"Tables\" WHERE  \"table_id\" = {id};";
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

        public async Task<IList<TableRes>> GetAllAsync(PaginationParams @params)
        {
            try
            {

                var list = new List<TableRes>();

                if (_connection.State == ConnectionState.Open)
                    await _connection.CloseAsync();
                await _connection.OpenAsync();



                string query = $"SELECT * FROM public.\"Tables\" ORDER BY table_id ASC ;";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = new TableRes();
                            item.Id = reader.GetInt64(0);
                            item.TableNumber = reader.GetByte(1);
                            item.SeatingCapasity = reader.GetByte(2);
                            item.status = (TableStatus)Enum.Parse(typeof(TableStatus), reader.GetString(3), true);
                            list.Add(item);
                        }
                    }

                }
                return list;
            }
            catch
            {
                return new List<TableRes>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<TableRes> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdatedAtAsync(long id, TableRes entity)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"Tables\"" +
                    $"SET table_number=@table_number, seating_capacity=@seating_capacity, status=@status WHERE \"table_id\" = {id};";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("table_number", entity.TableNumber);
                    command.Parameters.AddWithValue("seating_capacity", entity.SeatingCapasity);
                    command.Parameters.AddWithValue("status", entity.status.ToString());
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
