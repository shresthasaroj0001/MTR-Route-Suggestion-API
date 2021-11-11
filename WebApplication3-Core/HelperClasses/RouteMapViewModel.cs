using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_Core.Model;

namespace WebApplication3_Core.HelperClasses
{
    public class RouteMapViewModel
    {
        public List<Station> Stations { get; set; }
        public List<StationLink> StationLinks { get; set; }
        public RouteMapViewModel()
        {
            this.Stations = new List<Station>();
            this.StationLinks = new List<StationLink>();
        }
    }
}
