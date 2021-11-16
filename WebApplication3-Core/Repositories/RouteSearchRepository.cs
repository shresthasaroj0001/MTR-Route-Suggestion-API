using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_Core.HelperClasses;
using WebApplication3_Core.Model;

namespace WebApplication3_Core.Repositories
{
    public class RouteSearchRepository : IRouteSearchRepository
    {
        private readonly ApplicationDbContext _context;
        public RouteSearchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public GenericResponseObject<List<StationLink>> GetShortestRoute(int sourceId, int destinationId, string filterby)
        {
            GenericResponseObject<List<StationLink>> responseObject = new GenericResponseObject<List<StationLink>>();
            List<StationLink> shortestPathLink = new List<StationLink>();

            //validate stations
            var sourceObj = _context.Stations.Any(x => x.Id == sourceId);
            if (!sourceObj)
            {
                responseObject.Message = "Source Station Not found";
                return responseObject;
            }
            var destinationObj = _context.Stations.Any(x => x.Id == destinationId);
            if (!sourceObj)
            {
                responseObject.Message = "Destination Station Not found";
                return responseObject;
            }

            List<Station> stationList = _context.Stations.ToList();
            List<StationLink> stationLinks = _context.StationLinks.ToList();
            DirectedWeightGraph DSA = new DirectedWeightGraph();

            //create vertex
            foreach (Station station in stationList)
                DSA.InsertVertex(station.Id);

            //select weight
            foreach (StationLink _stationLink in stationLinks)
                DSA.InsertEdge(_stationLink.FromStationId, _stationLink.ToStationId, filterby == "station" ? 1 : (filterby == "fare" ? _stationLink.Fare : (float)_stationLink.Duration.TotalSeconds));

            List<int> FindPaths;
            try
            {
                FindPaths = DSA.FindPaths(sourceId, destinationId);

                if (FindPaths.Count == 0)
                    responseObject.Message = "Path not found";
                else
                {
                    for (int i = 1; i < FindPaths.Count; i++)
                    {
                        var link = stationLinks.Find(x => x.FromStationId == FindPaths[i] && x.ToStationId == FindPaths[i - 1]);
                        shortestPathLink.Add(link);
                    }
                    shortestPathLink.Add(stationLinks.Find(x => x.FromStationId == sourceId && x.ToStationId == FindPaths[FindPaths.Count - 1]));
                    responseObject.Message = "Path found successful";
                    responseObject.IsSuccess = true;
                }

                _context.RouteSearches.Add(new RouteSearch()
                {
                    FromStationId = sourceId,
                    ToStationId = destinationId,
                    DateSearched = DateTime.Now
                });
                _context.SaveChanges();
            }
            catch (Exception)
            {
                responseObject.Message = "Error while processing your request";
            }
            responseObject.Data = shortestPathLink;

            return responseObject;
        }

        public async Task<GenericResponseObject<List<StationLink>>> GetAllRoute()
        {
            GenericResponseObject<List<StationLink>> responseObject = new GenericResponseObject<List<StationLink>>();
            List<StationLink> models = new List<StationLink>();
            models = await _context.StationLinks.Include(x => x.FromStation).Include(y => y.ToStation).ToListAsync();
            responseObject.Data = models;
            responseObject.IsSuccess = true;
            responseObject.Message = "Retrieved Successfull";
            return responseObject;
        }

        public async Task<GenericResponseObject<List<RouteSearch>>> GetRouteSearches(int pageSize)
        {
            GenericResponseObject<List<RouteSearch>> responseObject = new GenericResponseObject<List<RouteSearch>>();
            List<RouteSearch> routeSeaches = new List<RouteSearch>();
            routeSeaches = await _context.RouteSearches.Include(x => x.FromStation).Include(y => y.ToStation).Skip(pageSize * 10).Take(10).ToListAsync();
            var totalResult = await _context.RouteSearches.CountAsync();

            responseObject.Data = routeSeaches;
            responseObject.IsSuccess = true;
            if (routeSeaches.Count() == 0)
                responseObject.Message = "No result found";
            else
                responseObject.Message = "Showing " + ((pageSize * 10) + 1) + " to " + ((pageSize * 10) + routeSeaches.Count()) + " of " + totalResult + " entries";//Showing 1 to 10 of 57 entries
            responseObject.PageSize = totalResult - (routeSeaches.Count() + pageSize * 10);
            return responseObject;
        }
    }
}
