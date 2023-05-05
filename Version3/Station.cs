using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Station
    {
        public string Name;
        public LinkedList<(Station, string, int)> Neighbours;
        public string Line;

        public Station(string name)
        {
            Name = name;
            Neighbours = new LinkedList<(Station, string, int)>();
        }

        public Station(string name, string line)
        {
            Name = name;
            Neighbours = new LinkedList<(Station, string, int)>();
            Line = line;
        }
    }
}
