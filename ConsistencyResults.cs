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
        private List<string> pathsTaken;
        private string route;

        public ConsistencyResults() 
        {
            // default results
            pathsTaken = new List<string>();
            route = string.Empty;
        }

        // get station path
        public List<string> GetPathsTaken()
        {
            return pathsTaken;
        }

        // get route 
        public string GetRoute()
        {
            return route;
        }
    }
}
