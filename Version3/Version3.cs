namespace Testing
{
    public class Version3 : ITestable
    {
        // fields

        // Dictionary to hold all stations, names = keys, station = station
        private Dictionary<string, Station> stations;

        // Property
        //// ITesable - name needed for testing ////
        public int VersionNumber { get; }



        // constructor
        public Version3(int version)
        {
            //// ITestable - initialise name ////
            VersionNumber = version;
            stations = new Dictionary<string, Station>();
            GenerateAdjacencyList();
        }

        // generates the adjacency list 
        public void GenerateAdjacencyList()
        {
            using (var reader = new StreamReader("stations3.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    string lineName = values[0];
                    string fromName = values[1];
                    string toName = values[2];
                    int time = int.Parse(values[3]);

                    Station fromStation, toStation;

                    // Check to make sure we don't get separate stations for (eg. bakerloo oxford st and central oxford st)
                    if (!stations.ContainsKey(fromName))
                    {
                        fromStation = new Station(fromName);
                        stations[fromName] = fromStation;
                    }
                    else
                    {
                        fromStation = stations[fromName];
                    }

                    if (!stations.ContainsKey(toName))
                    {
                        toStation = new Station(toName);
                        stations[toName] = toStation;
                    }
                    else
                    {
                        toStation = stations[toName];
                    }

                    // Add the connection between the two stations
                    fromStation.Neighbours.AddLast((toStation, lineName, time));
                    toStation.Neighbours.AddLast((fromStation, lineName, time));
                }
            } // end of Using StreamReader

        } // end of generating the adjacency list

        // main Dijkstra's implementation
        public JourneyLinkedList CalcualteShortestPath(string start, string end)
        {
            Station startStation = stations[start];
            Station endStation = stations[end];

            // Dijkstra's algo starts here
            var distances = new Dictionary<Station, int>();
            var previous = new Dictionary<Station, Station>();
            var queue = new List<Station>();

            // O of N as going through each element
            // initialising distances list
            foreach (var station in stations.Values)
            {
                if (station == startStation)
                {
                    distances[station] = 0;
                }
                else
                {
                    distances[station] = int.MaxValue;
                }

                queue.Add(station);
            }

            // total O of N^3 as N * N * N^3
            while (queue.Count > 0) // O of N as could have all stations in the queue

            {
                // sorting the queue big O of ? OrderBy() - uses Quicksort O(N*logN) average O(N2)
                var currentStation = queue.OrderBy(station => distances[station]).First();

                // is this needed?
                if (currentStation == endStation)
                {
                    break;
                }


                // O of 1
                queue.Remove(currentStation);

                // O of N as need to go through each neighbour (could be every station is neighbour?)
                foreach (var neighbour in currentStation.Neighbours)
                {
                    var alternativeDistance = distances[currentStation] + neighbour.Item3;

                    if (alternativeDistance < distances[neighbour.Item1])
                    {
                        distances[neighbour.Item1] = alternativeDistance;
                        previous[neighbour.Item1] = currentStation;
                    }
                }
            }

            // outputting shortest path
            var path = new LinkedList<Station>();
            var current = endStation;

            /////// testing - create JourneyLinkedList for data collection
            JourneyLinkedList route = new JourneyLinkedList("Version 3");

            // big O of N
            while (current != null)
            {
                path.AddFirst(current);
                current = previous.ContainsKey(current) ? previous[current] : null;
            }
            if (path.First.Value != startStation || path.Last.Value != endStation)
            {
                /////// testing - return an empty result
                return route;
            }

            var previousStation = default(Station);
            var currentLine = "";
            var totalTime = 0;

            foreach (var station in path)
            {
                if (previousStation != null)
                {
                    var neighbour = station.Neighbours.First(n => n.Item1 == previousStation);

                    /////// testing - add 'step' between stations to the overall journey
                    route.AddJourney(new Journey(previousStation.Name, station.Name, neighbour.Item3));

                    totalTime += neighbour.Item3;
                }
                currentLine = station.Line;
                previousStation = station;
            }

            /////// testing - add total time to JourneyLinkedList
            route.AddWalkTime(totalTime);

            // return the path as JourneyLinkedList object
            return route;

        } // end of CalculateShortestPath
    }
}
