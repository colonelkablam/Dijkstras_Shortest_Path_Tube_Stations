using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public interface ITestable
    {
        //public void GenerateAdjacencyList();
        public JourneyLinkedList CalcualteShortestPath(string start, string end);

    }
}
