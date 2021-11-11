using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_Core.HelperClasses;
using WebApplication3_Core.Model;

namespace WebApplication3_Core.Repositories
{
    public interface IRouteSearchRepository
    {
        GenericResponseObject<List<StationLink>> GetShortestRoute(int sourceId, int destinationId,string filterby);

        Task<GenericResponseObject<List<StationLink>>> GetAllRoute();
    }
}