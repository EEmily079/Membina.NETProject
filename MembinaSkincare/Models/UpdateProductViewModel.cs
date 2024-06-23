namespace MembinaSkincare.Models
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string BrandName { get; set; }
        public string ProductSeriesName { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string ProductDescription { get; set; }
        public double SGDPrice { get; set; }

        public decimal CurrencyRate { get; set; }
        public double MMKPrice { get; set; }
        public string PhotoLink { get; set; }
    }
}
