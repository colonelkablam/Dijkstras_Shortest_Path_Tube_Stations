using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    // create a result for a test of benchmarking times on a particular route
    public class BenchmarkResult
    {
        // fields
        private string route;
        private List<float> times;

        // structure to contain a result of a benchmark test
        public BenchmarkResult(string start, string end, List<float> times)
        {
            this.route = $"{start} - {end}"; // start and end stations as a string
            this.times = times; // add the times list
        }

        // return the route string
        public string GetRoute()
        {
            return route;
        }

        // return the time from a particular element
        public List<float> GetTimes()
        {
            return times;
        }

    }
}
