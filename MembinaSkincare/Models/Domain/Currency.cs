namespace MembinaSkincare.Models.Domain
{
    public class Currency
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public decimal CurrencyRate { get; set; }
        public List<Product> Products { get; set; }
        public Currency() { }

    }
}
