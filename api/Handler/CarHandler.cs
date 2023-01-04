using api.Models;

namespace api.Handler{
    public class CarHandler{
        public static List<Car> AllCars = new List<Car>();

        public CarHandler(){
        }

        public List<Car> GetAllCars(){
            return AllCars;
        }

        public void AddCar(Car newCar){
            AllCars.Add(newCar);
        }

       public void EditCar(string id, Car editCar){
            int index = AllCars.FindIndex(c => c.Id == id);
            AllCars.RemoveAt(index);

            AllCars.Add(editCar);
        }
        public void DeleteCar(string id){
            int index = AllCars.FindIndex(c => c.Id == id);
            AllCars.RemoveAt(index);
        }

    }
}