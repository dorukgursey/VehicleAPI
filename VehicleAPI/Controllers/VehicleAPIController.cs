using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;
using VehicleAPI.Repositories;


namespace VehicleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleAPIController : ControllerBase
    {
        private readonly VehicleRepository _repository;

        public VehicleAPIController(VehicleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("vehicles")]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles()
        {
            var vehicles = _repository.GetVehicles().OfType<Vehicle>();
            if (vehicles.Any())
            {
                return Ok(vehicles);
            }
            return NotFound();
        }

        [HttpGet("cars/{color}")]
        public ActionResult<IEnumerable<Vehicle>> GetCarsByColor(string color)
        {
            var cars = _repository.GetVehiclesByColor(color).OfType<Car>();
            if (cars.Any())
            {
                return Ok(cars);
            }
            return NotFound();
        }
        [HttpGet("buses/{color}")]
        public ActionResult<IEnumerable<Vehicle>> GetBusesByColor(string color)
        {
            var buses = _repository.GetVehiclesByColor(color).OfType<Bus>();
            if (buses.Any())
            {
                return Ok(buses);
            }
            return NotFound();
        }
        [HttpGet("boats/{color}")]
        public ActionResult<IEnumerable<Vehicle>> GetBoatsByColor(string color)
        {
            var boats = _repository.GetVehiclesByColor(color).OfType<Boat>();
            if (boats.Any())
            {
                return Ok(boats);
            }
            return NotFound();
        }

        [HttpPost("{id}/headlights")]
        public ActionResult TurnHeadlightsOnOff(int id, [FromBody] bool on)
        {
            var car = _repository.GetVehiclesById(id).OfType<Car>().FirstOrDefault();
            if (car != null)
            {
                car.TurnHeadlightsOnOff(on);
                return Ok();
            }
            return NotFound();
        }
        [HttpPost("{id}/Wheels")]
        public ActionResult PutWheelsOnOff(int id, [FromBody] bool on)
        {
            var car = _repository.GetVehiclesById(id).OfType<Car>().FirstOrDefault();
            if (car != null)
            {
                car.PutWheelsOnOff(on);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVehicle(int id)
        {
            _repository.DeleteVehicle(id);
            return NoContent();
        }
    }

}