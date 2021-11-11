using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3_Core.Model
{
    public class StationLink
    {
        public int Id { get; set; }
        [Required]
        public int SubwayLine { get; set; }
        
        [Required]
        public float Fare { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }

        [Required]
        public int FromStationId { get; set; }
        public virtual Station FromStation { get; set; }

        [Required]
        public int ToStationId { get; set; }
        public virtual Station ToStation { get; set; }
    }
}
