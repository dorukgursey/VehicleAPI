namespace VehicleAPI.Models
{
    public class Car : Vehicle
    {
        public bool Wheels { get; set; }
        public bool Headlights { get; set; }

        public void TurnHeadlightsOnOff(bool on)
        {
            Headlights = on;
        }
        public void PutWheelsOnOff(bool on)
        {
            Wheels = on;
        }
    }
}
