using System;
using System.Collections.Generic;

namespace Testing
{
    public class BenchmarkingResults
    {
        // a List of benchmarking result objects
        private List<BenchmarkResult> results;

        // constructor
        public BenchmarkingResults()
        {
            // default results
            results = new List<BenchmarkResult>();
        }

        // get benchmarkTimes 
        public List<BenchmarkResult> GetBenchmarkTimes()
        {
            return results;
        }

        // add benchmark times for a route 
        public void AddResult(string start, string end, List<float> times)
        {
            BenchmarkResult bm = new BenchmarkResult(start, end, times);
            results.Add(bm);
        }

        // get the results
        public List<BenchmarkResult> GetResults()
        {
            return results;
        }

        // get the results
        public void PrintResultsTable()
        {
            Console.WriteLine("BENCHMARKING Results Table:");
            foreach (var result in results)
            {
                Console.WriteLine($"{result.GetRoute}");
                foreach (var time in result.GetTimes())
                {
                    Console.WriteLine($"{time}");
                }
            }
        }
    }
}

