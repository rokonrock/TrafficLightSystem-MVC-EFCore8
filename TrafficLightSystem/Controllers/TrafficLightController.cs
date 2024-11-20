using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrafficLightSystem.Services;

namespace TrafficLightSystem.Controllers
{
    public class TrafficLightController : Controller
    {
        private readonly TrafficLightService _trafficLightService;

        public TrafficLightController(TrafficLightService trafficLightService)
        {
            _trafficLightService = trafficLightService;
        }

        public async Task<IActionResult> Index()
        {
            var currentColor = await _trafficLightService.GetNextColorAsync();
            ViewData["CurrentColor"] = currentColor;
            return View();
        }
    }
}
