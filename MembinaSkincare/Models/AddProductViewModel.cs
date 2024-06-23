using Microsoft.AspNetCore.Mvc.Rendering;

namespace MembinaSkincare.Models
{
    public class AddProductViewModel
    {
        public string Category { get; set; }
        public string BrandName { get; set; }
        public string ProductSeriesName { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string ProductDescription { get; set; }
        public double SGDPrice { get; set; }  // Change to double
        public double MMKPrice { get; set; }  // Change to double
        public string PhotoLink { get; set; }
        public string CurrencyName { get; set; }
        public List<SelectListItem> CurrencyOptions { get; set; }
    }

}
