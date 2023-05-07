using System;
using Testing;
using static System.Collections.Specialized.BitVector32;

namespace Adjacency
{
    public class DijkstraShortestPath
    {
        private string source;
        //private string destination;

        public DijkstraShortestPath()
        {

        }

        int numVertices = 63;

        public JourneyLinkedList DijkstraMethod(string source, string destination, WeightedEdge[] adjacencyList, WeightedEdge[] edges, int[] distTo, int versionNumber)
        {
            for (int i = 0; i < numVertices; i++)
            {
                distTo[i] = int.MaxValue;
            }

            PriorityQueue priqueue = new PriorityQueue(numVertices);

            priqueue.Enqueue(new Pair(0, source));

            while (!priqueue.IsEmpty())
            {
                Pair current = priqueue.Dequeue();
                string vertex = current.Name;
                int newDist = current.Distance;

                for (int i = 0; i < numVertices; i++)
                {
                    if (adjacencyList[i].Source == vertex)
                    {
                        WeightedEdge currentEdge = adjacencyList[i];

                        while (currentEdge != null)
                        {
                            string adjVertex = currentEdge.Destination;
                            int weight = currentEdge.Weight;
                            bool edgeFound = false;

                            for (int j = 0; j < numVertices; j++)
                            {
                                if (edges[j] != null && edges[j].Destination == adjVertex)
                                {
                                    edgeFound = true;
                                    if (distTo[j] > newDist + weight)
                                    {
                                        distTo[j] = newDist + weight;
                                        edges[j] = currentEdge;
                                        priqueue.Enqueue(new Pair(distTo[j], adjVertex));
                                    }
                                }
                            }

                            if (!edgeFound)
                            {
                                for (int j = 0; j < numVertices; j++)
                                {
                                    if (edges[j] == null)
                                    {
                                        edges[j] = currentEdge;
                                        distTo[j] = newDist + weight;
                                        priqueue.Enqueue(new Pair(distTo[j], adjVertex));
                                        break;
                                    }
                                }
                            }

                            currentEdge = currentEdge.Next;
                        }

                        break;
                    }
                }
            }

            //Display shortest path
            WeightedEdge[] pathArray = new WeightedEdge[63];

            WeightedEdge currentPathEdge;
            int totalTime = 0;
            int count = 0;
            bool cont = false;

            while (cont == false)
            {
                //Loop through edges array to find edge with destination
                for (int i = 0; i < numVertices; i++)
                {
                    if (edges[i] != null && edges[i].Destination == destination)
                    {
                        pathArray[count] = edges[i];
                        destination = edges[i].Source;
                        if (edges[i].Source == source)
                        {
                            cont = true;
                        }

                        break;
                    }
                }

                count++;
            }

            int routeCount = 1;

            /////// testing - create JourneyLinkedList for data collection
            JourneyLinkedList route = new JourneyLinkedList(versionNumber);

            for (int i = count - 1; i > -1; i--)
            {
                currentPathEdge = pathArray[i];

                /////// testing - add 'step' between stations to the overall journey
                route.AddJourney(new Journey(currentPathEdge.Source, currentPathEdge.Destination, currentPathEdge.Weight));

                totalTime = totalTime + currentPathEdge.Weight;
                routeCount++;

                /////// testing - add total time to JourneyLinkedList
                route.AddWalkTime(totalTime);
            }
            return route;
        }
    }
}

