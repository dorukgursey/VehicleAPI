using VehicleAPI.Models;

namespace VehicleAPI.Repositories
{
    public class VehicleRepository
    {
        private readonly List<Vehicle> _vehicles;

        public VehicleRepository()
        {
            _vehicles = new List<Vehicle>
            {
                new Car { Id = 1, Color = "Blue" },
                new Car { Id = 2, Color = "Red" },
                new Car { Id = 1, Color = "Green" },
                new Car { Id = 2, Color = "White" },
                new Bus { Id = 3, Color = "Black" },
                new Bus { Id = 4, Color = "White" },
                new Boat { Id = 5, Color = "Green" },
                new Boat { Id = 6, Color = "Red" }
            };
        }
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicles;
        }
        public IEnumerable<Vehicle> GetVehiclesByColor(string color)
        {
            return _vehicles.Where(v => v.Color.ToLower() == color.ToLower());
        }
        public IEnumerable<Vehicle> GetVehiclesById(int id)
        {
            return _vehicles.Where(v => v.Id == id);
        }

        public void DeleteVehicle(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle != null)
            {
                _vehicles.Remove(vehicle);

            }
        }
    }
}
