using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Handler;
using api.database.DataAccess;

namespace api.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {

        //Create : POST
        //Read : GET
        //Update : PUT
        //Delete : DELETE


        // GET: api/car
        [HttpGet]
        public List<Car> Get()
        {
            CarAccess myCarAccess = new CarAccess();
            return myCarAccess.GetCars();

        }

        // GET: api/car/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/car
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            CarAccess myCarAccess = new CarAccess();
            myCarAccess.AddCar(value);
        }

        // PUT: api/car/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Car value)
        {
            CarAccess myCarAccess = new CarAccess();
            myCarAccess.EditCar(value);
        }

        // DELETE: api/car/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            CarAccess myCarAccess = new CarAccess();
            myCarAccess.DeleteCar(id);
        }
    }
}
