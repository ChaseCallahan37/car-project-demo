namespace api.Models
{
    public class Car
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model {get; set; }
        public int Year { get; set; }

        public Car(){
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString(){
            return $"{Id} {Make} {Model} {Year}";
        }
    }
}