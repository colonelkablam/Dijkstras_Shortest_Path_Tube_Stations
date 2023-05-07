namespace Testing
{
    // create a result for a test of benchmarking times on a particular route
    public class BenchmarkResult
    {
        // fields
        private string route;
        private Dictionary<int, double> times;

        // structure to contain a result of a benchmark test
        public BenchmarkResult(string route)
        {
            this.times = new Dictionary<int, double>();  // add the times list
            this.route = route;
        }

        // add a time to the list
        public void AddTime(int version, double time)
        {
            times.Add(version, time);
        }

        // return the time from a particular element
        public void DisplayTimes()
        {
            Console.WriteLine($"Route: {route}");
                Console.WriteLine($"------------------------------------------------------");

            foreach (var time in times.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Version {time.Key}: average time taken per cycle: {time.Value.ToString("F2")} ms");
            }
            Console.WriteLine();
        }

    }
}
