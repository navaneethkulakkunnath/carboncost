using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hk20CarbonCost.Models
{
    public class AccountList
    {
        public List<Item> items { get; set; }
        public Links links { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Item
    {
        public string accountId { get; set; }
        public string accountName { get; set; }
        public string currency { get; set; }
        public string customerType { get; set; }
        public string accountType { get; set; }
        public string accountStatus { get; set; }
        public string accountOwnership { get; set; }
        public string postingsRestriction { get; set; }
        public string iban { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
        public bool templated { get; set; }
    }

    public class Next
    {
        public string href { get; set; }
        public bool templated { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public Next next { get; set; }
    }




}
