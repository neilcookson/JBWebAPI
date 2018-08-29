using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBWebAPI.Data.Models
{
    public class DataLoaderProduct
    {
        public int ProductID { get; set; }
        public string SKU { get; set; }
        public string DisplayName { get; set; }
        public bool BestSeller { get; set; }
        public double PlacedPrice { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int ReviewCount { get; set; }
        public double? Rating { get; set; }
        public string SalesFlags { get; set; }
        public string DeliveryStatus { get; set; }
        public string PickupStatus { get; set; }
        public bool OnlineAvailable { get; set; }
        public bool OnlineVisible { get; set; }
        public bool PreRelease { get; set; }
    }
}
