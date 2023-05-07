using System;
namespace Adjacency
{
    public class WeightedEdge
    {
        public string Source;
        public string Destination;
        public int Weight;
        public string Line;
        public WeightedEdge Next;

        public WeightedEdge(string source, string destination, int weight, string line, WeightedEdge next)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
            Line = line;
            Next = next;
        }
    }
}

