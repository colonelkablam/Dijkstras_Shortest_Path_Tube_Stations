using System;
using System.Collections.Generic;

namespace Testing
{
    public class BenchmarkResults
    {
        // a dictionary to store the benchmarking results from different routes
        private Dictionary<string, List<List<double>>> timesPerRoute;
        private string route;

        public BenchmarkResults()
        {
            // default results
            timesPerRoute = new Dictionary<string, List<List<double>>>();
            route = string.Empty;
        }

        // get station path
        public Dictionary<string, List<List<double>>> GetTimes()
        {
            return timesPerRoute;
        }

        // get route 
        public string GetRoute()
        {
            return route;
        }
    }
}

