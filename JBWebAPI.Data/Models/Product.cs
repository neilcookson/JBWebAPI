using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JBWebAPI.Data.Models
{
    public class Product
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

        public bool IsValid =>
            (!string.IsNullOrWhiteSpace(Brand)) &&
            (!string.IsNullOrWhiteSpace(DisplayName)) &&
            (!string.IsNullOrWhiteSpace(Category));


        public override bool Equals(object obj)
        {
            bool areEqual;
            var comparisonObject = (Product)obj;
            if (comparisonObject == null)
            {
                return false;
            }
            areEqual = Brand.Equals(comparisonObject.Brand);
            areEqual = DisplayName.Equals(comparisonObject.DisplayName);
            areEqual = ProductID.Equals(comparisonObject.ProductID);
            areEqual = Category.Equals(comparisonObject.Category);
            return areEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
