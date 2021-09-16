using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlightQuoteApp
{
    public class FlightService
    {
        public Task<FlightQuote> GetQuote(string site)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Get quote from site {site}");
                ThreadSleep(site);
                return new FlightQuote(site, GetRandomPrice());
            });
        }

        public Task<FlightQuote>[] GetQuotes()
        {
            var sites = new[] { "site1", "site2", "site3" };

            return (
                from s in sites
                select GetQuote(s))
                .ToArray();
        }

        private decimal GetRandomPrice()
        {
            return 100 + new Random().Next(0, 10);
        }

        private void ThreadSleep(string site)
        {
            var timeout = 1000 + new Random().Next(0, 2000);
            Console.WriteLine($"{site}: {Thread.GetCurrentProcessorId()} // {timeout} msec");
            Thread.Sleep(timeout);
        }
    }
}