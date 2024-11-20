using System.Threading.Tasks;
using TrafficLightSystem.Data;
using TrafficLightSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TrafficLightSystem.Services
{
    public class TrafficLightService
    {
        private readonly TrafficLightContext _context;

        public TrafficLightService(TrafficLightContext context)
        {
            _context = context;
        }

        public async Task<string> GetNextColorAsync()
        {
            var light = await _context.TrafficLights.FirstOrDefaultAsync();
            if (light == null)
            {
                light = new TrafficLight { CurrentColor = "Red", LastChanged = DateTime.Now };
                _context.TrafficLights.Add(light);
                await _context.SaveChangesAsync();
            }

            switch (light.CurrentColor)
            {
                case "Red":
                    light.CurrentColor = "Green";
                    break;
                case "Green":
                    light.CurrentColor = "Yellow";
                    break;
                case "Yellow":
                    light.CurrentColor = "Red";
                    break;
            }

            light.LastChanged = DateTime.Now;
            await _context.SaveChangesAsync();
            return light.CurrentColor;
        }
    }
}
