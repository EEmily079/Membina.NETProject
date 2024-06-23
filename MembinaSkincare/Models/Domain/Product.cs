namespace MembinaSkincare.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string BrandName { get; set; }
        public string ProductSeriesName { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string ProductDescription { get; set; }
        public double SGDPrice { get; set; }  // Change to double
        public double MMKPrice { get; set; }  // Change to double
        public string PhotoLink { get; set; }
        public decimal CurrencyRate { get; set; }  // Keep as decimal
        public int CurrencyId { get; set; }  // Foreign key
        public Currency Currency { get; set; }  // Navigation property


        public Product() { }

    }
}
