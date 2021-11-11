using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3_Core.Model
{
    public class RouteSearch
    {
        public int Id { get; set; }

        [Required]
        public int FromStationId { get; set; }
        public virtual Station FromStation { get; set; }

        [Required]
        public int ToStationId { get; set; }
        public virtual Station ToStation { get; set; }

        public DateTime DateSearched { get; set; }
    }
}
