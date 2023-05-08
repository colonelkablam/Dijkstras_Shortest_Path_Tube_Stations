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

        // clear tests
        public void ClearLog()
        {
            results.Clear();
        }

        // add a result
        public void AddResult(BenchmarkResult result)
        {
            results.Add(result);
        }
        // get tests count
        public int GetNumTests()
        {
            return results.Count;
        }

        // get the results
        public void DisplayResultsTable()
        {
            if (results.Count == 0)
            {
                Console.WriteLine($"               - no results -");
            }
            // iterate through version numbers (dictionary length is the number of diff routes tested)
            for (int i = 1; i <= results.Count; i++)
            {
                Console.WriteLine($"======================================================");
                Console.WriteLine($"              *** Test number {i} ***");
                Console.WriteLine($"======================================================");

                // display version being displayed
                results[i - 1].DisplayTimes();
                Console.WriteLine($"     =========    end of test {i}     ==========\n");

            }

        }
    }
}

