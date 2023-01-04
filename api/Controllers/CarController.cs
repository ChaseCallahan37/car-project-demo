using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Handler;

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
            CarHandler myCarHandler = new CarHandler();
            return myCarHandler.GetAllCars();
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
            CarHandler myCarHandler = new CarHandler();
            myCarHandler.AddCar(value);
        }

        // PUT: api/car/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Car value)
        {
            CarHandler myCarHandler = new CarHandler();
            myCarHandler.EditCar(id, value);
        }

        // DELETE: api/car/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            CarHandler myCarHandler = new CarHandler();
            myCarHandler.DeleteCar(id);
        }
    }
}
