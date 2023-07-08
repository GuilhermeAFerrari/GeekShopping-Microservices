using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Count { get; set; }

        public string SubstringName()
        {
            if (Name.Length < 24) return Name;
            return $"{Name.Substring(0, 21)} ...";
        }

        public string SubstringDescription()
        {
            if (Description.Length < 24) return Description;
            return $"{Description.Substring(0, 21)} ...";
        }
    }
}
