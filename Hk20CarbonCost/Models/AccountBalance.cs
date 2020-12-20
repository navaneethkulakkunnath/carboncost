using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hk20CarbonCost.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Amount
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class Balance
    {
        public string balanceType { get; set; }
        public Amount amount { get; set; }
        public DateTime dateTime { get; set; }
    }

    public class AccountBalance
    {
        public string accountId { get; set; }
        public List<Balance> balances { get; set; }
    }


}
