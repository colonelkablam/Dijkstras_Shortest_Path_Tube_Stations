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

        // add a result
        public void AddResult(BenchmarkResult result)
        {
            results.Add(result);
        }

        // get the results
        public void DisplayResultsTable()
        {
            if (results.Count() == 0)
            {
                Console.WriteLine($"               - no results -");
            }
            // iterate through version numbers (dictionary length is the number of diff routes tested)
            for (int i = 0; i < results.Count(); i++)
            {
                Console.WriteLine($"======================================================");
                Console.WriteLine($"            *** Test number {i + 1} ***");
                Console.WriteLine($"======================================================");

                // display version being displayed
                results[i].DisplayTimes();
            }

        }
    }
}

