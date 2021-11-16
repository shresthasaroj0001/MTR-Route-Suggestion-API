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
    public class StationLinkController : ControllerBase
    {
        private readonly IStationRepository _stationRepository;
        public StationLinkController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        [Route("/api/stationlink/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateStationLink([FromBody] StationLink stationlink)
        {
            await _stationRepository.UpdateStationLink(stationlink);
            return Ok();
        }
    }
}
