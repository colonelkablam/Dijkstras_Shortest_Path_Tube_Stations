using System;
using System.Collections.Generic;

namespace Testing
{
    public class BenchmarkResults
    {
        // a dictionary to store the benchmarking results from different routes
        private Dictionary<string, List<float>> benchmarkTimes;

        public BenchmarkResults()
        {
            // default results
            benchmarkTimes = new Dictionary<string, List<float>>();
        }

        // get benchmarkTimes 
        public Dictionary<string, List<float>> GetBenchmarkTimes()
        {
            return benchmarkTimes;
        }

        // add a benchmark time for a route 
        public void AddBenchmarkTime(string route, List<float> times)
        {
            benchmarkTimes.Add(route, times);
        }
    }
}

