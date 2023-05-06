using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class ConsistencyResults
    {
        // routes taken by the differnt versions
        private Dictionary<int, List<JourneyLinkedList>> routesTaken;

        public ConsistencyResults() 
        {
            // empty results dictionary
            routesTaken = new Dictionary<int, List<JourneyLinkedList>>();
        }

        // Add route
        public void AddRoutes(int v, List<JourneyLinkedList> route)
        {
            routesTaken.Add(v, route);
        }

        // Get route 
        public void DisplayResultsTable()
        {
            // iterate through version numbers (dictionary length will the number of diff routes tested)
            for (int i = 1; i <= routesTaken.Count(); i++)
            {
                Console.WriteLine($"Test Number {i}");
                Console.WriteLine($"===============");

                // interate through the different versions
                for (int j = 0; j < routesTaken[i].Count(); j++)
                {
                    // display version being displayed
                    Console.WriteLine($"Version {j+1}:");
                    routesTaken[i][j].DisplayAll();
                }
            }
            
        }
    }
}
