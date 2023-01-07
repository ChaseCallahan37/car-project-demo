using System.Data.SQLite;

namespace api.database
{
    public class DatabaseConnection
    {
        private static string _cs = @"URI=file:C:\Users\chase\OneDrive\Documents\Projects\School\CodingClubs\Class_Demo\demo_proj\api\database\car.db";


        public static SQLiteConnection GetDbConnection() {
            return new SQLiteConnection(_cs);
        }
    }
}