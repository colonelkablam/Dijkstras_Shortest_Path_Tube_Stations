using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace Testing
{


    public class Graph
    {
        private class Node
        {
            public TubeStation Station { get; }
            public Dictionary<Node, int> Neighbors { get; }

            public Node(TubeStation station)
            {
                Station = station;
                Neighbors = new Dictionary<Node, int>();
            }
        }

        private class DijkstraData
        {
            public Node Previous { get; set; }
            public int Distance { get; set; }
        }

        private Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        public void AddEdge(TubeStation from, TubeStation to, int distance)
        {
            Node fromNode = GetNode(from);
            Node toNode = GetNode(to);

            fromNode.Neighbors[toNode] = distance;
            toNode.Neighbors[fromNode] = distance; // For undirected graph
        }

        private Node GetNode(TubeStation station)
        {
            if (!nodes.ContainsKey(station.GetStationID()))
            {
                nodes[station.GetStationID()] = new Node(station);
            }

            return nodes[station.GetStationID()];
        }

        public JourneyLinkedList Dijkstra(TubeStation start, TubeStation end, int version)
        {
            if (!nodes.ContainsKey(start.GetStationID()) || !nodes.ContainsKey(end.GetStationID()))
            {
                return new JourneyLinkedList(version); // empty path
            }

            Node startNode = nodes[start.GetStationID()];
            Node endNode = nodes[end.GetStationID()];

            var data = nodes.ToDictionary(node => node.Value, node => new DijkstraData { Previous = null, Distance = int.MaxValue });
            data[startNode].Distance = 0;

            var queue = new SortedSet<Node>(Comparer<Node>.Create((node1, node2) => data[node1].Distance.CompareTo(data[node2].Distance)));
            queue.Add(startNode);

            while (queue.Count > 0)
            {
                Node current = queue.Min;
                queue.Remove(current);


                if (current == endNode)
                {
                    break;
                }

                foreach (var neighbor in current.Neighbors.Keys)
                {
                    int altDistance = data[current].Distance + current.Neighbors[neighbor];
                    if (altDistance < data[neighbor].Distance)
                    {
                        queue.Remove(neighbor);
                        data[neighbor].Distance = altDistance;
                        data[neighbor].Previous = current;
                        queue.Add(neighbor);
                    }
                }
            }

            ///// testing - cerate JourneyLinkedList to collect route ////
            JourneyLinkedList route = new JourneyLinkedList(version);
            try
            {

                for (Node node = endNode; node != null; node = data[node].Previous)
                {
                    // route.AddJourney(new Journey(node.Station.GetStationName() , data[node].Previous.Station.GetStationName(), 10));
                    route.AddJourney(new Journey(data[node].Previous.Station.GetStationName(), node.Station.GetStationName(), data[node].Distance));


                }
            }
            catch
            {
                route.AddJourney(new Journey("error", "error", -1));
            }

            //// testing - add total time to JourneyLinkedList ////
            route.AddWalkTime(100);

            // return route to call
            return route;
        }
    }
}

