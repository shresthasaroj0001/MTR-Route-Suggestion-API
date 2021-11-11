using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3_Core.Model;

namespace WebApplication3_Core.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly ApplicationDbContext _context;
        public StationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            return await _context.Stations.ToListAsync();
        }
    }
}
