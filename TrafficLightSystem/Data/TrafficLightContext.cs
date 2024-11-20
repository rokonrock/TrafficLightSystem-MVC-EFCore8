using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrafficLightSystem.Models;

namespace TrafficLightSystem.Data
{
    public class TrafficLightContext : DbContext
    {
        public TrafficLightContext(DbContextOptions<TrafficLightContext> options) : base(options) { }
        public DbSet<TrafficLight> TrafficLights { get; set; }
    }
}
