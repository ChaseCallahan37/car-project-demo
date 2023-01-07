using api.Models;
using System.Data.SQLite;


namespace api.database.DataAccess{
    public class CarAccess{
        public CarAccess(){
        }

        public void CreateCarTable()
        {
            using (SQLiteConnection con = DatabaseConnection.GetDbConnection())
            {
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = @"DROP TABLE IF EXISTS cars";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE cars
                                    (
                                        id STRING PRIMARY KEY,
                                        make STRING,
                                        model STRING,
                                        year INT    
                                    )";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"INSERT INTO cars(id, make, model, year)
                                        VALUES (@id, @make, @model, @year)";
                cmd.Parameters.AddWithValue("@id", "abc123");
                cmd.Parameters.AddWithValue("@make", "Toyota");
                cmd.Parameters.AddWithValue("@model", "4Runner");
                cmd.Parameters.AddWithValue("@year", 2004);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<Car> GetCars(){
            var cars = new List<Car>();
            using (SQLiteConnection con = DatabaseConnection.GetDbConnection()){
                con.Open();
                var cmd = new SQLiteCommand(con);
                    cmd.CommandText = @"SELECT * FROM cars";
                        using (SQLiteDataReader rdr = cmd.ExecuteReader()){
                            while(rdr.Read()){
                            cars.Add(
                                new Car() { 
                                    Id = rdr.GetString(0),
                                    Make = rdr.GetString(1),
                                    Model = rdr.GetString(2),
                                    Year = rdr.GetInt32(3) 
                                });
                            }
                        }
                con.Close();
            }
            return cars;
        }

        public void AddCar(Car newCar)
        {
            using (var con = DatabaseConnection.GetDbConnection())
            {
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = @"INSERT INTO cars (id, make, model, year)
                                    VALUES(@id, @make, @model, @year)";
                cmd.Parameters.AddWithValue("@id", newCar.Id);
                cmd.Parameters.AddWithValue("@make", newCar.Make);
                cmd.Parameters.AddWithValue("@model", newCar.Model);
                cmd.Parameters.AddWithValue("@year", newCar.Year);

                cmd.ExecuteNonQuery();

            }
        }

        public void EditCar(Car editCar){
            using(var con = DatabaseConnection.GetDbConnection()){
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = @"UPDATE cars
                                    SET make = @make,
                                        model = @model,
                                        year = @year
                                    WHERE id = @id;";
                cmd.Parameters.AddWithValue("@id", editCar.Id);
                cmd.Parameters.AddWithValue("@model", editCar.Model);
                cmd.Parameters.AddWithValue("@make", editCar.Make);
                cmd.Parameters.AddWithValue("@year", editCar.Year);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCar(string id){
            using(var con = DatabaseConnection.GetDbConnection()){
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = @"DELETE
                                    FROM cars
                                    WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
