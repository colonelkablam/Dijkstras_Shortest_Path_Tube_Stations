using System;
using System.Collections.Generic;

namespace Testing
{
    public class BenchmarkResults
    {
        // a List of benchmarking result objects
        private List<BenchmarkResult> results;

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

