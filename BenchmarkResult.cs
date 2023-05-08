namespace Testing
{
    // create a result for a test of benchmarking times on a particular route
    public class BenchmarkResult
    {
        // fields
        private string route;
        private int cycles;
        private Dictionary<int, double> times;

        // structure to contain a result of a benchmark test
        public BenchmarkResult(string route, int cycles)
        {
            this.times = new Dictionary<int, double>();  // add the times list
            this.route = route;
            this.cycles = cycles;
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
            Console.WriteLine($"Number of test cycles: {cycles}");

            Console.WriteLine($"------------------------------------------------------");

            foreach (var time in times.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Version {time.Key}: average time taken per cycle: {time.Value.ToString("F2")} ms");
            }
        }

    }
}
