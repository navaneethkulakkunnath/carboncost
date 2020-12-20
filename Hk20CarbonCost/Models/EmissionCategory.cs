using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hk20CarbonCost.Models
{
    public class EmissionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fee { get; set; }
    }
}
