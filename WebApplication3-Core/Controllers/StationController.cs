using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_Core.Model;
using WebApplication3_Core.Repositories;

namespace WebApplication3_Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationRepository _stationRepository;
        public StationController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetStations()
        {
            var stations = await _stationRepository.GetAllStations();
            return Ok(stations);
        }

        [Route("/api/station/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateStationDetail([FromBody]Station station)
        {
            await _stationRepository.UpdateStation(station);
            return Ok();
        }

    }
}
