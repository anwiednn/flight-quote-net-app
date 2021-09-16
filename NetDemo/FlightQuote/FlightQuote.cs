namespace NetDemo
{
    public class FlightQuote
    {
        public string Site { get; private set; }
        public decimal Price { get; private set; }

        public FlightQuote(string site, decimal price)
        {
            Site = site;
            Price = price;
        }

        public override string ToString()
        {
            return $"Quote{{site={Site}, Price={Price}}}";
        }
    }
}