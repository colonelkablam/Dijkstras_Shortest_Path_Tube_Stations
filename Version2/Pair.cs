using System;
namespace Adjacency
{
    public class Pair
    {
        public int Distance { get; set; }
        public string Name { get; set; }

        public Pair(int distance, string name)
        {
            Distance = distance;
            Name = name;
        }
    }
}

