
using Npgsql;
using Restaurant_Pos_Systeam_With_Wpf.Constans;

namespace Restaurant_Pos_Systeam_With_Wpf.Repositories;

public abstract class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        _connection = new NpgsqlConnection(ConstanDb.DB_CONNECTIONSTRING);
    }
}
