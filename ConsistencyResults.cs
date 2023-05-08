namespace Testing
{
    public class ConsistencyResults
    {
        // routes taken by the differnt versions
        private Dictionary<int, List<JourneyLinkedList>> routesTaken;
        // record the start and end stations for route tested 
        private List<string> testRoute;

        public ConsistencyResults()
        {
            // empty results dictionary
            routesTaken = new Dictionary<int, List<JourneyLinkedList>>();
            // empty route list
            testRoute = new List<string>();
        }

        // clear tests
        public void ClearLog()
        {
            routesTaken.Clear();
            testRoute.Clear();
        }

        // get number of test in dict
        public int GetNumTests()
        {
            return testRoute.Count;
        }

        // Add route
        public void AddRoutes(int v, List<JourneyLinkedList> route, string routeString)
        {
            routesTaken.Add(v, route);
            testRoute.Add(routeString);
        }

        // disply route 
        public void DisplayResultsTable()
        {
            if (routesTaken.Count == 0)
            {
                Console.WriteLine($"               - no results -");
            }
            // iterate through version numbers (dictionary length is the number of diff routes tested)
            for (int i = 1; i <= routesTaken.Count(); i++)
            {
                Console.WriteLine($"======================================================");
                Console.WriteLine($"              *** Test Number {i} ***");
                Console.WriteLine($"======================================================");
                Console.WriteLine($"Route: {testRoute[i - 1]}");


                // interate through the different versions
                for (int j = 0; j < routesTaken[i].Count; j++)
                {
                    // display version being displayed
                    routesTaken[i][j].DisplayAll();
                }
                Console.WriteLine($"     =========    end of test {i}     ==========\n");

            }

        }
    }
}
