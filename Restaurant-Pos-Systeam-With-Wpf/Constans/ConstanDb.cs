namespace Restaurant_Pos_Systeam_With_Wpf.Constans
{
    public class ConstanDb
    {
        public const string DB_Host = "localhost";
        public const string DB_Port = "5432";
        public const string DB_Datebase = "RestaurantDB";
        public const string DB_User = "Postgresql";
        public const string DB_Parol = "2151";

        public const string DB_CONNECTIONSTRING =
            $"Host :{DB_Host};" +
            $"Port: {DB_Port};" +
            $"Database : {DB_Datebase};" +
            $"User ID: {DB_User};" +
            $"Parol: {DB_Parol}";
    }
}
