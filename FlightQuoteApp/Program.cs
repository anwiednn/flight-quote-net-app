﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlightQuoteApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Main: {Thread.GetCurrentProcessorId()}");

            var startNow = DateTime.Now;
            var service = new FlightService();
            var tasks = service.GetQuotes();

            foreach (var task in tasks)
            {
                Console.WriteLine(await task);
            }

            await Task.WhenAll(tasks);
            var endNow = DateTime.Now;

            Console.WriteLine("All task comleted");
            Console.WriteLine($"Received all quotes in {(endNow - startNow).TotalMilliseconds} msec");
        }
    }
}