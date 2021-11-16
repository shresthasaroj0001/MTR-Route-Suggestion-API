using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_Core.Model;

namespace WebApplication3_Core.Repositories
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetAllStations();
        Task UpdateStation(Station station);
        Task UpdateStationLink(StationLink stationLink);
    }
}
