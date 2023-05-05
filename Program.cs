using System;              
using System.Diagnostics;  // StopWatch + TimeSpan
using System.Runtime.ConstrainedExecution;

namespace Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            /////////////// MEGA-TESTING PROG ///////////////////            

            // Dictionary to hold all stations, names = keys, station = station
            Dictionary<string, Station> stations = new Dictionary<string, Station>();
            // call function to populate stations dictionary from csv file
            PopulateStationsDictionay();

            // start and finish default stations
            string startStation = "Vauxhall";
            string endStation = "Paddington";

            // number of tests to run
            int testCycles = 10000;

            BenchmarkResults benchmarkResults = new BenchmarkResults();

            // start the menu
            bool exit = false;

            // main program loop to get inputs and run test
            while (exit == false)
            {
                Console.Clear();
                Console.WriteLine("******************************************************************");
                Console.WriteLine("Testing 3 Different Implementations of Dijkstra's Search Algorithm");
                Console.WriteLine("            - CONSISTENCY check and BENCHMARKING -");
                Console.WriteLine("******************************************************************");
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Input stations to walk between for CONSISTENCY check");
                Console.WriteLine("2. Choose number of tests cycles (1-100,000) for BENCHMARKING");
                Console.WriteLine("3. Run CONSISTENCY test");
                Console.WriteLine("4. Run BENCHMARK test");
                Console.WriteLine("5. Print results of tests");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                Console.WriteLine($"Current station selections:");
                Console.WriteLine($"start:\t\t{startStation}\nend:\t\t{endStation}");
                Console.WriteLine($"iterations: {testCycles}");
                Console.WriteLine();
                Console.Write("Enter your choice (1-6): ");

                // read user selection
                int selection;
                int.TryParse(Console.ReadLine(), out selection);

                switch (selection)
                {
                    // CHANGE START AND END STATIONS
                    case 1:
                        Console.Clear();
                        SelectStation();
                        break;
                    // CHANGE NUMBER OF TEST CYCLES
                    case 2:
                        Console.Clear();
                        InputNumberOfTests();
                        break;
                    // CONSISTANCY TEST
                    case 3:
                        if (startStation == string.Empty || endStation == string.Empty)
                        {
                            Console.WriteLine("No stations selected");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("////////////////////////////");
                            Console.WriteLine();
                            Console.WriteLine("Running Consistency test...");
                            Console.WriteLine();
                            Console.WriteLine("////////////////////////////");
                            Console.WriteLine();

                            // returns a TestResult object array
                            List<ConsistencyResults> resultsConsistency = RunConsistencyTest(startStation, endStation);
                        }

                        break;
                    // BENCHMARKING TEST
                    case 4:
                        if (startStation == string.Empty || endStation == string.Empty)
                        {
                            Console.WriteLine("No stations selected");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("////////////////////////////");
                            Console.WriteLine();
                            Console.WriteLine("Running Benchmarking test...");
                            Console.WriteLine();
                            Console.WriteLine("////////////////////////////");
                            Console.WriteLine();

                            // returns a BenchmarkResult object array
                            benchmarkResults = RunBenchmarkTest(startStation, endStation, testCycles);
                        }

                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine(benchmarkResults.GetBenchmarkTimes()[startStation + "/" + endStation].ToString());
                        Console.ReadKey();
                        
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1,2,3 or 4 only");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                }
            }  
            
            // FUNCTIONS

            // function to test CONSISTENCY
            List<ConsistencyResults> RunConsistencyTest(string startStation, string endStation)
            {
                // create an array to contain the test results
                List<ConsistencyResults> results = new List<ConsistencyResults>();

                // create an instance of solution 1
                Version3 version3 = new Version3();
                // generate its AL
                version3.GenerateAdjacencyList();

                // initialise return string representing path
                string calculatedPath = "no path returned by Version";

                // run the algo with the start and finish stations
                calculatedPath = version3.CalcualteShortestPath(startStation, endStation);

                Console.WriteLine($"Route to test: {startStation} to {endStation}");
                Console.WriteLine($"===============================================");
                Console.WriteLine($"Version 3:");
                Console.WriteLine($"{calculatedPath}");
                Console.WriteLine($"---------------------------------------------");

                Console.ReadKey();
                return results;

            }   // end of CONSISTENCY test

            // function to return BENCHMARK result for different paths for each version
            BenchmarkResults RunBenchmarkTest(string startStation, string endStation, int testCycles)
            {
                BenchmarkResults results = new BenchmarkResults();

                // create new stopwatches
                Stopwatch timer = new Stopwatch();

                // create an instance of solution 3
                Version3 version3 = new Version3();
                version3.GenerateAdjacencyList();

                // create an list to contain the test results for the route test per version
                List<float> result = new List<float>();

                //////////////////////////////////////////////// will need to iterate through versions


                // run the test the requested number of times
                for (int i = 0; i < testCycles; i++)
                {
                    // start the timer for V1
                    timer.Start();

                    // run the algo with the start and finish stations
                    version3.CalcualteShortestPath(startStation, endStation);

                    // stop the timer for V1
                    timer.Stop();
                }

                // get the timespan 
                TimeSpan timeTaken = timer.Elapsed;

                // get a float for the average per cycle
                float averageT = (float)timeTaken.Milliseconds / (float)testCycles;

                // add time taken per cycle to list
                result.Add(averageT);

                Console.WriteLine($"Route to test: {startStation} to {endStation}, {testCycles} cycles");
                Console.WriteLine($"=================================================================");
                Console.WriteLine($"Version 3: execution time per cycle: {averageT} ms");
                Console.WriteLine($"-----------------------------------------------------------------");

                results.AddBenchmarkTime(startStation + "/" + endStation, result); 

                // wait for key press
                Console.ReadKey();
                return results;

            }   // end of BENCHMARK test


            // function to select a valid station
            void SelectStation()
            {
                while(true)
                {
                    Console.WriteLine("Input start Station:");
                    startStation = Console.ReadLine();

                    if (stations.ContainsKey(startStation))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Input. Station Not Found.");
                }
                while (true)
                {
                    Console.WriteLine("Input end Station:");
                    endStation = Console.ReadLine();

                    if (stations.ContainsKey(endStation))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Input. Station Not Found.");
                }
            }

            // function to input valid number of tests
            void InputNumberOfTests()
            {
                int input = -1;
                Console.WriteLine("Please enter an number between 1000 - 1000000: ");
                if (int.TryParse(Console.ReadLine(), out input) & (input >= 1000 && input <= 1000000))
                {
                    testCycles = input;
                }
            }

            // function to create Stations Dictionary
            void PopulateStationsDictionay()
            { 

                // reading csv file and instantiating objects to pass into dictionary
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
                }
            }

        }
    }
}