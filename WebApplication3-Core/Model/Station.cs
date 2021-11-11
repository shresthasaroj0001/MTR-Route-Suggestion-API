using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3_Core.Model
{
    public class Station
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [StringLength(255)]
        public string Description { get; set; }

        //public virtual ICollection<StationLink> FromStations { get; set; }
        //public virtual ICollection<StationLink> ToStations { get; set; }
    }
}
