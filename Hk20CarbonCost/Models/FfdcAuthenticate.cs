using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hk20CarbonCost.Models
{
    public class FfdcAuthenticate
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public int refresh_expires_in { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
        public object id_token { get; set; }

    }
}
