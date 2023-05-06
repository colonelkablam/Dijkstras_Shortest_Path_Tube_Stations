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
        private List<JourneyLinkedList> routesTaken;

        public ConsistencyResults() 
        {
            // default results
            routesTaken = new List<JourneyLinkedList>();
        }

        // Add route
        public void AddRoute(JourneyLinkedList route)
        {
            routesTaken.Add(route);
        }

        // Get route 
        public void DisplayRoutes()
        {
            foreach (JourneyLinkedList route in routesTaken)
            {
                route.DisplayAll();
            }
            
        }
    }
}
