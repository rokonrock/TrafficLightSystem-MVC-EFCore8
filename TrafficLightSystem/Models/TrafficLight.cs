namespace TrafficLightSystem.Models
{
    public class TrafficLight
    {
        public int Id { get; set; }
        public string CurrentColor { get; set; }
        public DateTime LastChanged { get; set; }
    }
}
