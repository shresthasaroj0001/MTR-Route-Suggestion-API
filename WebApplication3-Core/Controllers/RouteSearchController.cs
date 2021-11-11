using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_Core.HelperClasses;
using WebApplication3_Core.Model;
using WebApplication3_Core.Repositories;

namespace WebApplication3_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteSearchController : ControllerBase
    {
        private readonly IRouteSearchRepository _routeSearchIRepository;

        public RouteSearchController(IRouteSearchRepository routeSearchIRepository)
        {
            _routeSearchIRepository = routeSearchIRepository;
        }

        [Route("/api/routesearch/findshortestroute")]
        [HttpGet]
        public IActionResult FindShortestRoute([FromQuery] RouteSearchQueryParameter queryParameter ) //not nullable
        {
            if (queryParameter.to == queryParameter.from)
                return BadRequest();
            if (queryParameter.filterby == null)
                queryParameter.filterby = "station";
            else //station,fare,duration
            {
                queryParameter.filterby = queryParameter.filterby.ToLower();
                if (queryParameter.filterby != "station" || queryParameter.filterby != "fare" || queryParameter.filterby != "duration")
                    queryParameter.filterby = "station";
            }
                
            GenericResponseObject<List<StationLink>> responseObject = _routeSearchIRepository.GetShortestRoute(queryParameter.from, queryParameter.to, queryParameter.filterby);
            
            return Ok(responseObject);
        }

        [Route("/api/routesearch/GetAllRoute")]
        [HttpGet]
        public async Task<IActionResult> GetAllRoute()
        {
           var routes = await _routeSearchIRepository.GetAllRoute();
            return Ok(routes);
        }

    }
}
